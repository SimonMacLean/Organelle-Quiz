using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organelle_Quiz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string[] getLines(string input)
        {
            List<string> linesList = new List<string>();
            input += "\n";
            while (input != string.Empty)
            {
                string s = string.Empty;
                while (input[0] != '\n')
                {
                    s += input[0].ToString();
                    input = input.Substring(1);
                }
                input = input.Substring(1);
                linesList.Add(s);
            }
            return linesList.ToArray<string>();
        }
    }
    public class Cell
    {
        string cellTypeName;
        List<Organelle> cellOrganelles;
        Point location;
        public Cell(int X, int Y, string name)
        {
            cellTypeName = name;
            cellOrganelles = new List<Organelle>();
            location = new Point(X, Y);
        }
        public void defineOrganelle(string name, Bitmap image, Bitmap highlighted, Point relativeLocation, string definition)
        {
            cellOrganelles.Add(new Organelle(name, image, highlighted, new Point(location.X + relativeLocation.X, location.Y + relativeLocation.Y), definition));
        }
    }
    public class Organelle
    {
        string name;
        Bitmap imageNormal;
        Bitmap imageHighlighted;
        Point location;
        List<Question> riddles;
        string definition;
        List<Question> defQuestions;
        public Organelle(string name, Bitmap image, Bitmap highlighted, Point location, string definition)
        {
            this.name = name;
            imageNormal = image;
            imageHighlighted = highlighted;
            this.location = location;
            this.definition = definition;
        }
        public void addQuestion(Question question)
        {
            defQuestions.Add(question);
        }
        public void addRiddle(Question riddle)
        {
            riddles.Add(riddle);
        }
        public void addQuestions(string questionsText)
        {
            string[] questionStrings = Form1.getLines(questionsText);

        }
    }
    public class Question
    {
        string questionText;
        string[] options;
        bool[] correct;
        public Question(string question, string[] choices, bool[] isCorrect)
        {
            questionText = question;
            options = choices;
            correct = isCorrect;
        }
        public Question(string questionText)
        {

        }
        string printText()
        {
            string result = string.Empty;
            result += questionText;
            for(int i = 0; i < options.Length; i++)
            {
                result += "\n   " + i.ToString() + ". " + options[i] + "\n";
            }
            return result;
        }
        bool isTrue(int place)
        {
            if (place > correct.Length || place < 0)
                return false;
            return correct[place];
        }
    }
}
