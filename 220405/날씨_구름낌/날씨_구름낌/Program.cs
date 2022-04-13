// 파이썬으로 하면 진짜 한줄임
// print(input(eval()))

// C# 코드입니다.

using System.Text.RegularExpressions;
//string input = Console.ReadLine();

string input = "10-20+10";
//string input = "1+1*(1*(1+1)/1)*((10+10*1)/1)"; // 41
//string input = "(1+1*1)+((1+1)/1)*((15-10*1)/1)"; // 12
int start_point = 0;
int end_point = 0;
string calc_point;
int calc_index = 0;
int temp_int_one = 0;
int temp_int_two = 0;
string temp_one;
string temp_two;

char[] operChars = { '+', '-', '*', '/', '(', ')' };
string[] calcValue = input.Split(operChars);
//char[] calcOper = calcValue.Split();
//string calcOper = Regex.Replace(input, @"[0-9]", "", RegexOptions.Singleline);
//Console.WriteLine(calcOper);
//calcOper.ToCharArray();
double calc = 0;



while (input.Contains('('))                                         // 괄호가 있다면 
{
    start_point = input.LastIndexOf('(') + 1;                         // 마지막 여는 괄호에서 
    end_point = input[start_point..].IndexOf(')') + start_point;      // 가장 가까운 닫는 괄호까지 
    calc_point = input[start_point..end_point];                     // 묶은 것이 가장 먼저 계산할 목표 
    int input_len = input.Length;
    Console.WriteLine(calc_point);
    while (true)
    {
        if (calc_point.Contains('*'))                               // 연산 우선 순위에 따라 곱셈부터 
        {
            calc_index = calc_point.IndexOf('*');

            temp_one = calc_point[..calc_index].Split(operChars)[^1];
            temp_two = calc_point[calc_index..].Split(operChars)[1];

            temp_int_one = calc_point[..calc_index].Split(operChars)[^1].Length;         // 좌항 자릿수 
            temp_int_two = calc_point[calc_index..].Split(operChars)[1].Length;          // 우항 자릿수 
            // 식을 간소화하기 위해선 인덱스가 필요하기 때문에 * 기준으로 양옆 수의 길이를 저장 


            temp_int_one = calc_index - temp_int_one;               // calc_point 를 초기화 시키기 위해 인덱스 저장 
            temp_int_two = calc_index + temp_int_two + 1;

            calc = int.Parse(temp_one) * int.Parse(temp_two);

            calc_point = calc_point[..temp_int_one] + calc + calc_point[temp_int_two..];    // 계산된 식은 값으로 바꿔서 반환
            Console.WriteLine(calc_point);
        }
        else if (calc_point.Contains('/'))
        {
            calc_index = calc_point.IndexOf('/');

            temp_one = calc_point[..calc_index].Split(operChars)[^1];
            temp_two = calc_point[calc_index..].Split(operChars)[1];

            temp_int_one = calc_point[..calc_index].Split(operChars)[^1].Length;         // 좌항 자릿수 
            temp_int_two = calc_point[calc_index..].Split(operChars)[1].Length;          // 우항 자릿수 


            temp_int_one = calc_index - temp_int_one;               // calc_point 를 초기화 시키기 위해 인덱스 저장 
            temp_int_two = calc_index + temp_int_two + 1;

            calc = int.Parse(temp_one) / int.Parse(temp_two);

            calc_point = calc_point[..temp_int_one] + calc + calc_point[temp_int_two..];    // 계산된 식은 값으로 바꿔서 반환
            Console.WriteLine(calc_point);
        }
        else if (calc_point.Contains('+'))
        {
            calc_index = calc_point.IndexOf('+');

            temp_one = calc_point[..calc_index].Split(operChars)[^1];
            temp_two = calc_point[calc_index..].Split(operChars)[1];

            temp_int_one = calc_point[..calc_index].Split(operChars)[^1].Length;         // 좌항 자릿수 
            temp_int_two = calc_point[calc_index..].Split(operChars)[1].Length;          // 우항 자릿수 


            temp_int_one = calc_index - temp_int_one;               // calc_point 를 초기화 시키기 위해 인덱스 저장 
            temp_int_two = calc_index + temp_int_two + 1;

            calc = int.Parse(temp_one) + int.Parse(temp_two);

            calc_point = calc_point[..temp_int_one] + calc + calc_point[temp_int_two..];    // 계산된 식은 값으로 바꿔서 반환
            Console.WriteLine(calc_point);
        }
        else if (calc_point.Contains('-'))
        {
            calc_index = calc_point.IndexOf('-');

            temp_one = calc_point[..calc_index].Split(operChars)[^1];
            temp_two = calc_point[calc_index..].Split(operChars)[1];

            temp_int_one = calc_point[..calc_index].Split(operChars)[^1].Length;         // 좌항 자릿수 
            temp_int_two = calc_point[calc_index..].Split(operChars)[1].Length;          // 우항 자릿수 


            temp_int_one = calc_index - temp_int_one;               // calc_point 를 초기화 시키기 위해 인덱스 저장 
            temp_int_two = calc_index + temp_int_two + 1;

            calc = int.Parse(temp_one) - int.Parse(temp_two);

            calc_point = calc_point[..temp_int_one] + calc + calc_point[temp_int_two..];    // 계산된 식은 값으로 바꿔서 반환
            Console.WriteLine(calc_point);
        }
        else // 연산자가 더 이상 없으면 
        {
            start_point = start_point - 1; // 괄호를 제외해주기 위해 -1
            if (end_point == input_len - 1) // index error 발생 > 값이 마지막일 때 예외처리 필요!!  모름 …
            {
                input = input[..start_point] + calc_point;
            }
            else
            {
                end_point = end_point + 1; // 괄호를 제외해주기 위해 +1
                input = input[..start_point] + calc_point + input[end_point..];
            }
            break;
        }
    }
    //Console.WriteLine(calc_point);
}

// 괄호가 없는 남은 값 계산 

while (true)
{
    if (input.Contains('*'))                                                    // input 값을 직접 변
    {
        calc_index = input.IndexOf('*');

        temp_one = input[..calc_index].Split(operChars)[^1];
        temp_two = input[calc_index..].Split(operChars)[1];

        temp_int_one = input[..calc_index].Split(operChars)[^1].Length;         // 좌항 자릿수 
        temp_int_two = input[calc_index..].Split(operChars)[1].Length;          // 우항 자릿수 


        temp_int_one = calc_index - temp_int_one;
        temp_int_two = calc_index + temp_int_two + 1;

        calc = int.Parse(temp_one) * int.Parse(temp_two);

        input = input[..temp_int_one] + calc + input[temp_int_two..];    // 계산된 식은 값으로 바꿔서 반환
        Console.WriteLine(input);
    }
    else if (input.Contains('/'))                                                    // input 값을 직접 변
    {
        calc_index = input.IndexOf('/');

        temp_one = input[..calc_index].Split(operChars)[^1];
        temp_two = input[calc_index..].Split(operChars)[1];

        temp_int_one = input[..calc_index].Split(operChars)[^1].Length;         // 좌항 자릿수 
        temp_int_two = input[calc_index..].Split(operChars)[1].Length;          // 우항 자릿수 


        temp_int_one = calc_index - temp_int_one;
        temp_int_two = calc_index + temp_int_two + 1;

        calc = int.Parse(temp_one) / int.Parse(temp_two);

        input = input[..temp_int_one] + calc + input[temp_int_two..];    // 계산된 식은 값으로 바꿔서 반환
        Console.WriteLine(input);
    }
    else if (input.Contains('-'))                                                    // input 값을 직접 변
    {
        calc_index = input.IndexOf('-');

        if (input.IndexOf('-') != 0)
        {

            temp_one = input[..calc_index].Split(operChars)[^1];
            temp_two = input[calc_index..].Split(operChars)[1];

            temp_int_one = input[..calc_index].Split(operChars)[^1].Length;         // 좌항 자릿수 
            temp_int_two = input[calc_index..].Split(operChars)[1].Length;          // 우항 자릿수 


            temp_int_one = calc_index - temp_int_one;
            temp_int_two = calc_index + temp_int_two + 1;

            calc = int.Parse(temp_one) - int.Parse(temp_two);

            input = input[..temp_int_one] + calc + input[temp_int_two..];    // 계산된 식은 값으로 바꿔서 반환
            Console.WriteLine(input);
        }

        else
        {
            if (input.Split(operChars).Length == 2)
            {
                Console.WriteLine(input);
                break;
            }
            else
            {
                string calcOper = Regex.Replace(input, @"[0-9]", "", RegexOptions.Singleline);

                temp_one = input[calc_index..].Split(operChars)[1];
                temp_two = input[calc_index..].Split(operChars)[2];

                temp_int_one = input[calc_index..].Split(operChars)[1].Length;         // 좌항 자릿수 
                temp_int_two = input[calc_index..].Split(operChars)[2].Length;          // 우항 자릿수

                int temp_int_sum = temp_int_one + temp_int_two + 2;

                if (calcOper[1] == '+')
                {
                    calc = -int.Parse(temp_one) + int.Parse(temp_two);
                }
                else if (calcOper[1] == '-')
                {
                    calc = -int.Parse(temp_one) - int.Parse(temp_two);
                }

                input = calc + input[temp_int_sum..];    // 계산된 식은 값으로 바꿔서 반환
                Console.WriteLine(calc);

                Console.WriteLine(input);
            }
        }
    }
    else if (input.Contains('+'))                                                    // input 값을 직접 변
    {
        calc_index = input.IndexOf('+');

        temp_one = input[..calc_index].Split(operChars)[^1];
        temp_two = input[calc_index..].Split(operChars)[1];

        temp_int_one = input[..calc_index].Split(operChars)[^1].Length;         // 좌항 자릿수 
        temp_int_two = input[calc_index..].Split(operChars)[1].Length;          // 우항 자릿수 


        temp_int_one = calc_index - temp_int_one;
        temp_int_two = calc_index + temp_int_two + 1;

        calc = int.Parse(temp_one) + int.Parse(temp_two);

        input = input[..temp_int_one] + calc + input[temp_int_two..];    // 계산된 식은 값으로 바꿔서 반환
        Console.WriteLine(input);
    }
    else // 연산자가 더 이상 없으면 
    {
        Console.WriteLine(input);
        break;
    }
}

