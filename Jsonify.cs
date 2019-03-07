using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace tester
{
    public static class Jsonify
    {
        public static async Task SerializeToFile(string fileName, object obj)
        {
            using (StreamWriter file = File.CreateText(fileName))
            {
                var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
                await file.WriteAsync(json);
            }
        }

    }
}
