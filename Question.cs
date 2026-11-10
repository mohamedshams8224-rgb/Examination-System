using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_System 
{ 


    abstract class Question
    {
        public Question(string header, int marks, Enums.QuestionLevel level)
        {
            Header = header;
            Marks = marks;
            Level = level;
        }

        public string Header { get; set; } 
        public int Marks { get; set; }
        public Enums.QuestionLevel Level { get; set; }
        public  abstract void Display();
        public  abstract bool CheckAnswer(string answer);

    }
    class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string header, int marks, Enums.QuestionLevel level , bool correctAnsewer) : base(header, marks, level)
        {
            CorrectAnswer = correctAnsewer;
        }
        public bool CorrectAnswer  { get; set; }
        public override void Display()
        {
            Console.WriteLine($"{Header}\n" +
                $" true (t) /  false (f) ?"); 
        }
        public override bool CheckAnswer(string answer)
        {
            return ( answer.ToLower() == CorrectAnswer.ToString().ToLower() ) || answer.ToLower() == "t" ;
        }
    }
    class ChooseOneQuestion : Question
    {
        public ChooseOneQuestion(string header, int marks, Enums.QuestionLevel level , string[] choices , int correctanswer) : base(header, marks, level)
        {                                                                              // 1- s                   // 3 .
                                                                                       // 2- f
                                                                                       // 3- d
                                                                                       // 4- r
            Choices = choices;
            CorrectAnswer = correctanswer;
        }
        public string[] Choices { get; set; } = new string[4]; 
        public int CorrectAnswer { get; set;  }

        public override bool CheckAnswer(string answer)
        {
            for(int i = 0; i < Choices.Length; i ++)
            {
                if (answer == Choices[i] && CorrectAnswer == i + 1)
                    return true;
            }
            if (int.TryParse(answer, out int ansWer) && ansWer == CorrectAnswer)
                return true;
            return false;
        }

        public override void Display()
        {
            Console.WriteLine(Header);
            int i = 1;
            foreach(string item in Choices)
            {
                Console.WriteLine($"{i++} - {item}");
            }

        }
    }
    class MultipleChoiceQuestion : Question
    {
        public MultipleChoiceQuestion(string header, int marks, Enums.QuestionLevel level , string[] choices, int[] correctAnswer) : base(header, marks, level)
        {
            Choices = choices;
            CorrectAnswer = correctAnswer;
        }
        public string[] Choices { get; set; } = new string[4];
        public int[] CorrectAnswer { get; set; } = new int[2];

        public override bool CheckAnswer(string answer)
        {
            for (int i = 0; i < Choices.Length; i++)
            {
                if(answer.ToLower() == Choices[i].ToLower() && CorrectAnswer.Contains(i+1))
                {
                    return true;
                }
            }
            if (int.TryParse(answer, out int ansWer) && CorrectAnswer.Contains(ansWer))
                return true;
            return false;
        }

        public override void Display()
        {
            Console.WriteLine(Header);
            int i = 1;
            foreach (string item in Choices)
            {
                Console.WriteLine($"{i++} - {item}");
            }
        }
    }


}
