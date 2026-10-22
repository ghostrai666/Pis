using Xunit;

namespace igra.Tests
{
    public class ConsoleRenderTests
    {
        // Вызывает Draw и возвращает всё, что он напечатал, разбитое на строки
        private string[] TestDraw(char[,] map, Player player, List<GameObject> objects)
        {
            StringWriter writer = new StringWriter();

            TextWriter oldOut = Console.Out;

            Console.SetOut(writer);                              


            ConsoleRender render = new ConsoleRender();   
            render.Draw(map, player, objects);            


            Console.SetOut(oldOut);                              

            return writer.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries); // возвращаем строку
        }

        // Тест 1: у каждого предмета свой символ
        [Fact]
        public void GetSymbol_ReturnsSymbolOfObject()
        {
            ConsoleRender render = new ConsoleRender();

            Assert.Equal('*', render.GetSymbol(new Axe(0, 0)));
            Assert.Equal('^', render.GetSymbol(new Torch(0, 0)));
            Assert.Equal('@', render.GetSymbol(new Spider(0, 0)));
        }

        // Тест 2: без факела игрок видит квадрат 5 на 5
        [Fact]
        public void Draw_WithoutTorch_ShowsFiveRows()
        {
            char[,] map = new char[3, 3];                       
            Player player = new Player(1, 1); // игрок в центре
            List<GameObject> objects = new List<GameObject> { new Axe(0, 0) }; // топор в левом верхнем углу

            string[] rows = TestDraw(map, player, objects);

            Assert.Equal(5, rows.Length);
            Assert.Equal("     ", rows[0]);   
            Assert.Equal(" *.. ", rows[1]);   
            Assert.Equal(" .#. ", rows[2]);   
            Assert.Equal(" ... ", rows[3]);   
            Assert.Equal("     ", rows[4]);   
        }

        // Тест 3: с факелом игрок видит квадрат 7 на 7
        [Fact]
        public void Draw_WithTorch_ShowsSevenRows()
        {
            char[,] map = new char[3, 3];
            Player player = new Player(1, 1);
            player.HasTorch = true;

            string[] rows = TestDraw(map, player, new List<GameObject>());

            Assert.Equal(7, rows.Length);
            Assert.Equal(7, rows[0].Length);
        }
    }
}