internal class Program
{
    class Quest
    {
        public int[] Max_return()
        {
            string[] input = Console.ReadLine().Split(" ");

            int max_value = -1;
            int max_index = -1;
            int value = -1;
            int index_count = 0;

            foreach (var item in input)
            {
                index_count++; // 1부터 시작하기
                value = int.Parse(item);
                if (value > max_value)
                {
                    max_value = value;
                    max_index = index_count;
                }
            }

            Console.WriteLine("최대값 = " + max_value + "\n" + max_index + "번째에 위치");

            int[] max_Values = { max_value, max_index };

            return max_Values;
        }

        public int Cost_of_Add(string defalut_input = "뀨")
        {

            List<int> add_list = new List<int>();
            List<int> min_sum_list = new List<int>();
            int count = 0;
            int temp_sum = 0;
            int min_index = 0;
            int min_sum = 0;
            int temp = 0;
            string[] input;
            
            if (defalut_input == "뀨")
            {
                input = Console.ReadLine().Split(" ");
            }
            else
            {
                input = defalut_input.Split(" ");
            }

            count = input.Length;

            for (int i = 0; i < count; i++)
            {
                temp = int.Parse(input[i]);
                add_list.Add(temp);
                if (i == 0)
                {
                    min_sum_list.Add(temp);
                }
                else
                {
                    for (min_index = 0; min_index < i; min_index++)
                    {
                        if (temp > min_sum_list[min_index])
                        {
                            continue;
                        }
                        break;
                    }
                    min_sum_list.Insert(min_index, temp); // Sort를 사용하는 방법도 있음
                }


                temp_sum = temp_sum + add_list[i] * (count - i); // [i]*(n-1) + [i+1]*(n-1) + [i+2]*(n-2) + [i+3]*(n-3) ... + [count-1]
            }
            Console.Write("최소비용 계산 순서 : ");
            for (int i = 0; i < count; i++)
            {
                min_sum = min_sum + min_sum_list[i] * (count - i);
                Console.Write(min_sum_list[i]+" ");
            }

            Console.WriteLine();
            Console.WriteLine("순서대로 연산 시 : " + (temp_sum - add_list[0]));
            Console.WriteLine("최소비용 연산 시 : " + (min_sum - min_sum_list[0]));
            return min_sum;
        }
    }

    static void Main(string[] arg)
    {
        Quest q = new Quest();
        //q.Max_return();
        //q.Cost_of_Add();
        q.Cost_of_Add("1 2 3");
        q.Cost_of_Add("3 2 1");
        q.Cost_of_Add("1 3 2");
        q.Cost_of_Add("1 2 3 4 6");
        q.Cost_of_Add("3 6 4 8 9 7");
        q.Cost_of_Add("1 1 4 2 8 8 8");
    }
    
}