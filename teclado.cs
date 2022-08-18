namespace WinFormsApp1
{
    using Microsoft.VisualBasic;
    using System;
    using System.Data;

   


    public partial class teclado : Form
    {
        public teclado()
        {
            InitializeComponent();
        }

        public static class app
        {
            public static string expresion = "";
            public static int onStack { get; set; }  /* elementos en la pila */
        }


        private void Show_one(object sender, EventArgs e)
        {
            string theInput = (sender as Button).Text ;
            
          switch (theInput)
            {
                case "+":
                case "-":
                case "/":
                case "*":
                    /*leyendo operadores */
                    calcScreen.Text += " " + theInput + " ";
                    break;
                case "=":
                    try
                    {
                        DataTable dt = new DataTable();
                        var v = dt.Compute(app.expresion, null).ToString();

                        if( v == null ) throw new Exception("bad op");

                        calcScreen.Text += Environment.NewLine + v + Environment.NewLine;

                    } catch (Exception)
                    {
                        calcScreen.Text = "ERROR";
                    }
                    
                    app.expresion = "";
                    theInput = "";
                    
                    break;

                default: /*leyendo numeros */
                    calcScreen.Text += theInput;
                    
                    //app.expresion += theInput;
                    break;
            }//switch
            
            app.expresion +=   theInput;

        }
    }

    //public partial class push

}