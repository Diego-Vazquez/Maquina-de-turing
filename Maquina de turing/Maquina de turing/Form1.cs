using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maquina_de_turing
{
    public partial class Form1 : Form
    {
        private String cadena;
        private String cadena2;
        private String auxiliar;
        private int estado=0;
        private bool correr = false;
        string[] arreglo;
        private int apuntador=1;
        public Form1()
        {
            InitializeComponent();
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            actualizar_apuntador();
            correr = false;
            button3.Enabled = false;
            switch(estado){
                case 0: { q0(); break; }
                case 1: { q1(); break; }
                case 2: { q2(); break; }
                case 3: { q3(); break; }
                case 4: { q4(); break; }
            }
        }

        public void Apuntar()
        {
            switch (apuntador)
            {
                case 0: { txt12.Text = "^"; break; }
                case 1: { txt13.Text = "^"; break; }
                case 2: { txt14.Text = "^"; break; }
                case 3: { txt15.Text = "^"; break; }
                case 4: { txt16.Text = "^"; break; }
                case 5: { txt17.Text = "^"; break; }
                case 6: { txt18.Text = "^"; break; }
                case 7: { txt19.Text = "^"; break; }
                case 8: { txt20.Text = "^"; break; }
                case 9: { txt21.Text = "^"; break; }
                case 10: { txt22.Text = "^"; break; }
            }
        }
        public void actualizar(string dato)
        {
            switch (apuntador)
            {
                case 1: { txt2.Text = dato; break; }
                case 2: { txt3.Text = dato; break; }
                case 3: { txt4.Text = dato; break; }
                case 4: { txt5.Text = dato; break; }
                case 5: { txt6.Text = dato; break; }
                case 6: { txt7.Text = dato; break; }
                case 7: { txt8.Text = dato; break; }
                case 8: { txt9.Text = dato; break; }
                case 9: { txt10.Text = dato; break; }
                case 10: { txt11.Text = dato; break; }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                button1.Enabled = false;
                button3.Enabled = false;
                cadena = "";
                cadena2 = "";
                estado = 0;
                apuntador = 1;
                correr = false;
                auxiliar = "";
                MessageBox.Show("Aún no se a ingresado una cadena de texto", "Alerta");
            }
            else
            {
                cadena = "";
                cadena2 = "";
                estado = 0;
                apuntador = 1;
                correr = false;
                auxiliar = "";
                button1.Enabled = true;
                button3.Enabled = true;
                actualizar_apuntador();
                cadena = textBox1.Text;
            cadena2 = "#"+cadena+"#";
            arreglo=new string[cadena2.Length];
            for(int i=0;i<cadena2.Length;i++){
                arreglo[i] = Convert.ToString(cadena2.ElementAt(i));
            }
            iniciar_cinta();
            }
           
        }


        public void derecha()
        {
            apuntador++;
        }

        public void isquierda()
        {
            apuntador--;
        }

        public void iniciar_cinta()
        {
            int posicion = 0;
            while (posicion < cadena2.Length)
            {
                switch (posicion)
                {
                    case 0: { txt1.Text = arreglo[0]; break; }
                    case 1: { txt2.Text = arreglo[1]; break; }
                    case 2: { txt3.Text = arreglo[2]; break; }
                    case 3: { txt4.Text = arreglo[3]; break; }
                    case 4: { txt5.Text = arreglo[4]; break; }
                    case 5: { txt6.Text = arreglo[5]; break; }
                    case 6: { txt7.Text = arreglo[6]; break; }
                    case 7: { txt8.Text = arreglo[7]; break; }
                    case 8: { txt9.Text = arreglo[8]; break; }
                    case 9: { txt10.Text = arreglo[9]; break; }
                    case 10: { txt11.Text = arreglo[10]; break; }
                   
                }
                posicion++;
            }
            txt12.Text = "^";
        } 

        public void actualizar_apuntador(){
            txt12.Text = ".";
            txt13.Text = ".";
            txt14.Text = ".";
            txt15.Text = ".";
            txt16.Text = ".";
            txt17.Text = ".";
            txt18.Text = ".";
            txt19.Text = ".";
            txt20.Text = ".";
            txt21.Text = ".";
            txt22.Text = ".";
        }
        
        // ************* estados ************************************************* 
        //*************************************

        public void q0(){
            actualizar_apuntador();
            Apuntar();
            auxiliar = arreglo[apuntador];
            if (auxiliar.Equals("1")) { arreglo[apuntador] = "x"; actualizar("x"); derecha(); if (correr) { q1(); estado = 1;  } else { estado = 1; } }
            else if (auxiliar.Equals("B")) { arreglo[apuntador] = "B"; actualizar("B"); derecha(); if (correr) { q3(); estado = 3; } else { estado = 3; } }
            else{button1.Enabled = false; button3.Enabled = false; MessageBox.Show("Caracter invalido: "+auxiliar, "Alerta");}
        }

        public void q1()
        {
            actualizar_apuntador();
            Apuntar();
            auxiliar = arreglo[apuntador];
            if (auxiliar.Equals("1")) { arreglo[apuntador] = "1"; actualizar("1"); derecha(); if (correr) { q1(); estado = 1; } else { estado = 1; } }
            else if (auxiliar.Equals("B")) { arreglo[apuntador] = "B"; actualizar("B"); derecha(); if (correr) { q1(); estado = 1; } else { estado = 1; } }
            else if (auxiliar.Equals("A")) { arreglo[apuntador] = "B"; actualizar("B"); isquierda(); if (correr) { q2(); estado = 2; } else { estado = 2; } }
            else { button1.Enabled = false; button3.Enabled = false; MessageBox.Show("Caracter invalido: "+auxiliar, "Alerta"); }

        }

        public void q2()
        {
            actualizar_apuntador();
            Apuntar();
            auxiliar = arreglo[apuntador];
            if (auxiliar.Equals("1")) { arreglo[apuntador] = "1"; actualizar("1"); isquierda(); if (correr) { q2(); estado = 2; } else { estado = 2; } }
            else if (auxiliar.Equals("B")) { arreglo[apuntador] = "B"; actualizar("B"); isquierda(); if (correr) { q2(); estado = 2; } else { estado = 2; } }
            else if (auxiliar.Equals("x")) { arreglo[apuntador] = "1"; actualizar("1"); derecha(); if (correr) { q0(); estado = 0; } else { estado = 0; } }
            else { button1.Enabled = false; button3.Enabled = false; MessageBox.Show("Caracter invalido: "+auxiliar, "Alerta"); }

        }

        public void q3()
        {
            actualizar_apuntador();
            Apuntar();
            auxiliar = arreglo[apuntador];
            if (auxiliar.Equals("A")) { arreglo[apuntador] = "A"; actualizar("A"); derecha(); if (correr) { q3(); estado = 3;} else { estado = 3; } }
            else if (auxiliar.Equals("B")) { arreglo[apuntador] = "B"; actualizar("B"); derecha(); if (correr) { q3(); estado = 3;  } else { estado = 3; } }
            else if (auxiliar.Equals("#")) { arreglo[apuntador] = "#"; actualizar("#"); derecha(); if (correr) { q4(); estado = 4;  } else { estado = 4; } }
            else { button1.Enabled = false; button3.Enabled = false; MessageBox.Show("Caracter invalido: "+auxiliar, "Alerta"); }
        }

        public void q4()
        {

            actualizar_apuntador();
            Apuntar();
            correr = false;
            button1.Enabled = false;
            button3.Enabled = false;
            MessageBox.Show("   Cadena Valida", " ");
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            correr = true;
            q0();
        }




      
    }
}
