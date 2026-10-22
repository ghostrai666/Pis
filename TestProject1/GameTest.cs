using igra;
using Xunit;

namespace TestProject1
{
    public class LoadMapTests
    {
        // Тест 1: карта из файла читается без изменений
        [Fact]
        public void LoadMap_ValidFile_MapMatchesFile()
        {
            string[] lines = { "..*.", "#...", ".^.@" }; // условная карта

            File.WriteAllLines("test_map.txt", lines); // записываем во временный файл

            char[,] map = Game.LoadMap("test_map.txt"); // прогоняем через LoadMap


            Assert.Equal(3, map.GetLength(0)); // утверждаю что, 3 = map.GetLength(0)
            Assert.Equal(4, map.GetLength(1)); // утверждаю что, 4 = map.GetLength(1)

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    Assert.Equal(lines[y][x], map[y, x]); // символ в карте = символ в файле
                }
            }

            File.Delete("test_map.txt"); // удаление этого файла
        }

        // Тест 2: если файла нет, будет ошибка
        [Fact]
        public void LoadMap_FileNotFound_Exception()
        {
            Assert.Throws<Exception>(() => Game.LoadMap("фейк_файл.txt"));
        }

        [Theory]
        [InlineData('*')]
        [InlineData('^')]
        [InlineData('@')]
        [InlineData('.')]
        public void LoadMap_AllowedSymbol_IsLoaded(char symbol)
        {
            File.WriteAllText("test_map1.txt", "#" + symbol);

            char[,] map = Game.LoadMap("test_map1.txt");

            Assert.Equal(symbol, map[0, 1]);   

            File.Delete("test_map1.txt");
        }
    }
}
