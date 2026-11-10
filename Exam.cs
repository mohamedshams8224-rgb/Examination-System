using Examination_System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_System
{
    class Exam
    {
        public List<Question> Questions { get; set; } = new List<Question>();
        public List<Question> EasyQuestions = new List<Question>();
        public List<Question> MediumQuestions = new List<Question>();
        public List<Question> HardQuestions = new List<Question>();

    }
    class Doctor: Exam
    {
        public void AddQuestion(Question question)
        {
            Questions.Add(question);
            if (question.Level == Enums.QuestionLevel.Easy)
            {
                EasyQuestions.Add(question);
            }
            else if (question.Level == Enums.QuestionLevel.Medium)
            {
                MediumQuestions.Add(question);
            }
            else
            {
                HardQuestions.Add(question);
            }
        }
    }
    class Student:Exam
    {
        public void ChooseExam(Enums.ExamType examType , Enums.QuestionLevel level)
        {
            if(examType == Enums.ExamType.Final)
            {
                switch (level)
                {
                    case Enums.QuestionLevel.Easy:
                        foreach (Question q in EasyQuestions)
                            q.Display();
                        break;
                    case Enums.QuestionLevel.Medium:
                        foreach (Question q in MediumQuestions)
                            q.Display();
                        break;
                    case Enums.QuestionLevel.Hard:
                        foreach (Question q in HardQuestions)
                            q.Display();
                        break;
                }
            }
            if(examType == Enums.ExamType.Practical)
            {

                switch (level)
                {
                    case Enums.QuestionLevel.Easy:
                        for (int i = 0; i < EasyQuestions.Count / 2; i++)
                            EasyQuestions[i].Display();
                        break;
                    case Enums.QuestionLevel.Medium:
                        for (int i = 0; i < MediumQuestions.Count / 2; i++)
                            MediumQuestions[i].Display();
                        break;
                    case Enums.QuestionLevel.Hard:
                        for (int i = 0; i < HardQuestions.Count / 2; i++)
                            HardQuestions[i].Display();
                        break;
                    
                }
            }
        }
    }
}
