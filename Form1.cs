using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Linq_Queries
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //#1To diaply Name which constains "good" only.
        private void btnFirst_Click(object sender, EventArgs e)
        {
            // string collection list
            IList<string> stringList = new List<string>() {
                       "Life is good",
                         "Life is hard",
                                "good things happens to good people",
                               "my work is very hard" ,
                                      "Your life is hard"
                                          };

            // LINQ Query :A statement that defines the query expression
            var result = from s in stringList
                         where s.Contains("good")
                         select s;
            //Code that executes the query
            foreach (var str in result)

            {
                MessageBox.Show(str.ToString(), "Results");
            }
        }


        //#2get the name which have length more than 5, order by length
        private void btnSecond_Click(object sender, EventArgs e)
        {
            // string collection list
            List<string> myfriendsNames = new List<string>
               {"Sudh", "karanGrover", "shivamgahi", "dhruvibhatt", "jack"};

            // LINQ Query :A statement that defines the query expression
            IEnumerable<string> frindsNames =
                from name in myfriendsNames
                where name.Length >= 5
                orderby name.Length
                select name;

            //Code that executes the query
            foreach (var name in frindsNames)
            {

                MessageBox.Show(name.ToString(), "Results");
            }
        }


        //#3 get elements from the first array based on the values in the second array.
        private void btnThird_Click(object sender, EventArgs e)
        {
            //Creating first array
            var myArray1 = new int[3];
            myArray1[0] = 4;
            myArray1[1] = 3;
            myArray1[2] = 0;

            //Creating Second array
            var myArray2 = new int[3];
            myArray2[0] = 5;
            myArray2[1] = 4;
            myArray2[2] = 2;

            //join with query expression.
            var myResult = from t in myArray1
                         join x in myArray2 on (t + 1) equals x
                         select t;

            //Code that executes the query display elements of array1
            foreach (var r in myResult)
            {

                MessageBox.Show(r.ToString(), "Results");
            }


        }



           //#4. Display the elemnets in order ,first odd then even from array using another function.
        
        static bool IsEven(int value)   //function to check even/odd
        {
            return value % 2 == 0;
        }
        private void btnFourth_Click(object sender, EventArgs e)
        {
            // Input array.
            int[] myArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // LINQ Query :A statement that defines the query expression.
            var myResult = from element in myArray
                         orderby element
                         group element by IsEven(element);

            //Code that executes the query and display odd elements first then even in order
            foreach (var group in myResult)
            {
                // Display key and its values.
                foreach (var value in group)
                {
                    MessageBox.Show(value.ToString(), "Results");
                }
            }

        }



        //#5 It uses the let keyword and computes let by multiplying the element's value by 50.
        //tested (>= 300) and selected into the result.
        private void btnFifth_Click(object sender, EventArgs e)
        {


            // Creating an aray of type int
            int[] myArray = { 1, 4, 3, 8, 6 ,7};


           // LINQ Query :A statement that defines the query expression
            var myResult = from element in myArray
                         let v = element * 50
                         where v >= 300
                         select v;

            //Code that executes the query and display element based on condition (>=300)
            foreach (var element in myResult)
            {
                MessageBox.Show(element.ToString(), "Results");

            }
        }



        //#6  query expression to sort these objects from high to low Balance and display respected ID.

        class CheckBalance   //Class for Data model
        {
            public int Balance { get; set; }
            public int Id { get; set; }
        }
        private void btnSixth_Click(object sender, EventArgs e)
        {
            //Creating Object of class CheckBalance and adding data
            CheckBalance[] array = new CheckBalance[]
        {
            new CheckBalance(){Balance = 20000, Id = 4},               
            new CheckBalance(){Balance = 40000, Id = 1},
            new CheckBalance(){Balance = 90000, Id = 7},
            new CheckBalance(){Balance = 60000, Id = 10}
        };
            // LINQ Query :A statement that defines the query expression
            var myResult = from em in array
                         orderby em.Balance descending, em.Id ascending
                         select em;

            //Code that executes the query and display ID based on balance(high to low)
            foreach (var em in myResult) {

                MessageBox.Show(em.Id.ToString());
            } }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
