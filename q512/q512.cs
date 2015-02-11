using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;

namespace q512
{
    public partial class q512 : Form
    {

        private Bitmap myCanvas;
        Pen graphPen = new Pen(Color.White, 1);
        Font graphFont = new Font("Courier New", 8);
        SolidBrush graphBrush = new SolidBrush(Color.DimGray);
        Pen linePen = new Pen(Color.LightBlue, 1);
        string eq;
        double oldX, oldY, newX, newY;
        int pixOldX, pixOldY, pixNewX, pixNewY;
        Random rand = new Random();
        SolidBrush globBrush = new SolidBrush(Color.Green);

        public q512()
        {
            InitializeComponent();
        }

        private void q512_Load(object sender, EventArgs e)
        {
            myCanvas = new Bitmap(401, 401,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(myCanvas);
            g.Clear(Color.Black);
            oldX = -10.0;
            oldY = 0.0;
            newX = -9.0;
            newY = 0.0;
            pixOldX = 0;
            pixNewX = 20;

            /*Green Glob*/
            for (int i = 0; i < 10; i++)
            {
                g.FillEllipse(globBrush, ((rand.Next(0, 20)) * 20) - 5, ((rand.Next(0, 20)) * 20) - 5, 10, 10);
            }

        }

        private void q512_Paint(object sender, PaintEventArgs e)
        {
            
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(myCanvas, 30, 30, myCanvas.Width, myCanvas.Height);
            for (int i = 0; i <= 20; i++)
            {
                for (int j = 0; j <= 20; j++)
                {
                    g.DrawEllipse(graphPen, (30 + 20 * i), (30 + 20 * j), 1, 1);
                }
            }
            for (int k = 0; k <= 20; k++)
            {
                g.DrawLine(graphPen, (30 + 20 * k), 225, (30 + 20 * k), 235);
                g.DrawLine(graphPen, 225, (30 + 20 * k), 235, (30 + 20 * k));
                if (k % 5 == 0)
                {
                    Point stringPointXAxis = new Point(30 + 20 * k, 230);
                    Point stringPointYAxis = new Point(230, 30 + 20 * k);
                    g.DrawLine(graphPen, (30 + 20 * k), 220, (30 + 20 * k), 240);
                    g.DrawLine(graphPen, 220, (30 + 20 * k), 240, (30 + 20 * k));
                    g.DrawString((k - 10).ToString(), graphFont, graphBrush, stringPointXAxis);
                    g.DrawString((10 - k).ToString(), graphFont, graphBrush, stringPointYAxis);
                }
            }
            g.DrawLine(graphPen, 30, 230, 430, 230);
            g.DrawLine(graphPen, 230, 30, 230, 430);
            
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            animationTimer.Start();
            eq = eqTextBox.Text;
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(myCanvas);

            eq = eqTextBox.Text;
            eq = eq.Replace("x", newX.ToString());
            newY = ProcessCommand(eq);
            pixNewY = 200 - (int)newY * 20;

            eq = eqTextBox.Text;
            eq = eq.Replace("x", oldX.ToString());
            oldY = ProcessCommand(eq);
            pixOldY = 200 - (int)oldY * 20;

            g.DrawLine(linePen, pixOldX, pixOldY, pixNewX, pixNewY);
            //g.DrawLine(linePen, (int) (oldX + 10) * 20, (200 - (int)oldY * 20), (int)(newX + 10) * 20, (200 - (int)newY * 20));

            oldX+=1;
            newX+=1;
            pixOldX += 20;
            pixNewX += 20;
            this.Refresh();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            animationTimer.Stop();
            Graphics g = Graphics.FromImage(myCanvas);
            
        }

        /// <summary>
        /// A simple function to get the result of a C# expression (basic and advanced math possible)
        /// </summary>
        /// <param name="command">String value containing an expression that can evaluate to a double.</param>
        /// <returns>a Double value after evaluating the command string.</returns> 
        private double ProcessCommand(string command)
        {
            //Create a C# Code Provider
            CSharpCodeProvider myCodeProvider = new CSharpCodeProvider();
            // Build the parameters for source compilation.
            CompilerParameters cp = new CompilerParameters();
            cp.GenerateExecutable = false;//No need to make an EXE file here.
            cp.GenerateInMemory = true;   //But we do need one in memory.
            cp.OutputAssembly = "TempModule"; //This is not necessary, however, if used repeatedly, causes the CLR to not need to
            //load a new assembly each time the function is run.
            //The below string is basically the shell of a C# program, that does nothing, but contains an
            //Evaluate() method for our purposes.  I realize this leaves the app open to injection attacks,
            //But this is a simple demonstration.
            string TempModuleSource = "namespace ns{" +
                                      "using System;" +
                                      "class class1{" +
                                      "public static double Evaluate(){return " + command + ";}}} ";  //Our actual Expression evaluator
            CompilerResults cr = myCodeProvider.CompileAssemblyFromSource(cp, TempModuleSource);
            if (cr.Errors.Count > 0)
            {
                //If a compiler error is generated, we will throw an exception because
                //the syntax was wrong - again, this is left up to the implementer to verify syntax before
                //calling the function.  The calling code could trap this in a try loop, and notify a user
                //the command was not understood, for example.
                throw new ArgumentException("Expression cannot be evaluated, please use a valid C# expression");
            }
            else
            {
                MethodInfo Methinfo = cr.CompiledAssembly.GetType("ns.class1").GetMethod("Evaluate");
                return (double)Methinfo.Invoke(null, null);
            }
        }



    }
}