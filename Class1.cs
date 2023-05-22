using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJJ24
{
    // 데이터를 외부에 저장하거나 외부의 데이터를 불러오는 역할
    internal class SaveManager
    {
        private static string GetPath(string fileName)
        {
            // 세이브 데이터가 저장되는 root폴더 경로이다. 만약 해당 결로에 폴더가 없으면 새로 생성한다.
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "SaveData");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            return Path.Combine(directoryPath, $"{fileName}pkm");
        }
        // 어떠한 객체를 저장할 것인지
        public static void Save(string fileName, Inventory data)
        {
            // filename을 경로로 data를 json로 변환한 뒤에 파일을 쓰자
            string path = GetPath(fileName);
            string json = JsonConvert.SerializeObject(data);
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(json);
            }

        }
        public static Inventory Load(string fileName)
        {
            // 경로에 있는 파일을 읽어들인 뒤 json을 다시 Inventory로 Deserialize
            string path = GetPath($"{fileName}");
            string json = string.Empty;
            using (StreamReader sr = new StreamReader(path))
            {
                json = sr.ReadToEnd(); 
            }
            return JsonConvert.DeserializeObject<Inventory>(json);


        }

    }
}
