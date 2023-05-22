using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace JJJ24
{
    class Item
    {
        public int id;
        public string name;
        public string description;
        public int price;
        // Deserialize를 수행하기 위하여 기본형을 제작해준다.
        public Item()
        {
            id = 0;
            name = string.Empty;
            description = string.Empty;
            price = 0;
        }
        public Item(int id, string name, string description, int price)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.price = price;
        }
        public Item(string csv)
        {
            string[] data = csv.Split(',');

            id = int.Parse(data[0]);
            name = data[1];
            description = data[2];
            price = int.Parse(data[3]);
        }
    }
    class Inventory
    {
        public List<Item> items;
        public int money;

        public Inventory()
        {
            items = new List<Item>();
            money = 0;
        }

    }
    internal class Program
    {
        public static int CombineBigNum(int a, int b)
        {
            string ab = string.Concat(a, b);
            string ba = string.Concat(b, a);

            string bigger = ab.CompareTo(ba) == -1 ? ba : ab;

            return int.Parse(bigger);
/*
            if (int.Parse(ab) >= int.Parse(ba))
            {
                return int.Parse(ab);
            }
            else
            {
                return int.Parse(ba);
            }
*/



        }

        public static int[] RepeatNum(int[] nums)
        {   
            // 1 
            return nums.SelectMany(num => Enumerable.Repeat(num, num)).ToArray();
            
            // 2
            List<int> list = new List<int>();
            foreach (int num in nums)
            {
                list.AddRange(Enumerable.Repeat(num, num));
            }
            return list.ToArray();

            // 3
            List<int> result = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int e = nums[i];
                for (int j = 0; j < e; j++)
                {
                    result.Add(e);
                }
            }

            return result.ToArray();

        }

        static void Main(string[] args)
        {
            /*
            Console.WriteLine(CombineBigNum(125, 15));


            // Q. 배열의 원소만큼 추가하기(int[])
            // 1은 배열에 '1' 하나, 6은 배열에 '6' 6개

            int[] nums = { 1, 2, 3, 4, 5, 6 };
            Console.WriteLine(string.Concat(RepeatNum(nums)));
            */

            // 2교시
            /*
            // 파일 쓰기
            // 상대 경로(현재 exe 파일이 있는 경로)
            string root = Directory.GetCurrentDirectory();
            root = string.Concat(root, "/save.txt");

            // 실행시 디렉토리 위치에 txt 파일이 생성 됨
            // using : StreamWriter를 어디까지 사용할 것인지 영역으로 지정 후 자동으로 해제 (미사용시 Close로 닫아줘야한다.)
            using (StreamWriter sw = new StreamWriter(root))
            {
                sw.WriteLine("파일에 데이터를 쓸 수 있다.");
                // sw.Close();
            }

            // 데이터 저장형식
            // xml, csv, tsv, json...

            root = Directory.GetCurrentDirectory();
            const string FOLDER_DATA = "Data";
            string fileName = "item.csv";

            // string.Concat() : 문자열 결합
            // Path.Combine() : 경로 결합
            string path = string.Concat(root, "/",FOLDER_DATA, "/", fileName);
            path = Path.Combine(root, FOLDER_DATA, fileName);
            
            Console.WriteLine("경로 : " +path);
            Console.WriteLine($"파일이 있는가 : {File.Exists(path)}");

            // 경로 관련 함수
            // - 바로 이전 경로 찾기
            // - 파일 있는 폴더명 가져오기
            // - 파일 명 가져오기
            // - 파일 확장자 가져오기

            Console.WriteLine($"폴더경로 : {Path.GetDirectoryName(path)}");
            Console.WriteLine($"루트경로 : {Path.GetPathRoot(path)}");
            Console.WriteLine($"파일(+확장자)명 : {Path.GetFileName(path)}");
            Console.WriteLine($"파일명 : {Path.GetFileNameWithoutExtension(path)}");
            Console.WriteLine($"확장명 : {Path.GetExtension(path)}");
            Console.WriteLine();

            if(File.Exists(path))
            {
                // 한글자 읽기 : Read
                // 한 줄 읽기 : ReadLine
                // 끝까지 읽기 : ReadToEnd

                string read = string.Empty;
              
                using(StreamReader sr = new StreamReader(path))
                {
                    read = sr.ReadToEnd();
                }
                // Console.WriteLine(read);

                // 특정 문자를 기준으로 문자열을 잘라서 배열로 변환 
                string[] lines = read.Split('\n');

                List<Item> items = new List<Item>();
                for(int i = 1; i < lines.Length; i++)
                // 0번째 인덱스는 카테고리를 나눈 개요이기 때문에 생략한다.
                {
                    items.Add(new Item(lines[i]));
                }

                Console.WriteLine($"{items[3].name} : {items[3].description}");


            }
            */

            // 3교시

            // json
            // 객체를 데이터로 표현하기 위해 만들어진 파일 형식이다.
            // 때문에 별다른 조치 없이 데이터 형태에서 객체 형식으로 변환이 가능하다.

            // tool - Nuget - Manage에서 Browser에서 Newtonsoft설치
            // using문에 using Newtonsoft.Json; 추가

            Item item = new Item(0, "몬스터볼", "일반적인 볼이다.", 1000);

            // 객체를 json형태의 문자열로 변환
            string jso = JsonConvert.SerializeObject(item);
            Console.WriteLine(jso);

            Inventory inven = new Inventory();
            inven.items.Add(new Item(0, "몬스터볼", "일반적인 볼이다.", 1000));
            inven.items.Add(new Item(1, "몬터볼", " 볼이다.", 2000));
            inven.items.Add(new Item(2, "볼", "적 볼이다.", 3000));
            inven.money = 100;

            // 나머지는 다운
        }
    }
}