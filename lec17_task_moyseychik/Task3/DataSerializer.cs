using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Task3
{
    //JSON data serialization static functions.
    public static class DataSerializer
    {
        //Async JSON serialization to specified file.
        public static async void SerializeToFile(
            List<EmployeeVacations> data, string file)
        {
            using FileStream fileStream = File.Create(file);

            JsonSerializerOptions options = new()
            {
                WriteIndented = true
            };

            await JsonSerializer.SerializeAsync(fileStream, 
                data, options);
        }
    }
}
