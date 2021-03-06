﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica28
{
    public partial class Graficadora : Form
    {
        private int n, ci, cf, fi, ff, c, f;
        private double x, y, xi, xf, yi, yf, h;

        public Graficadora()
        {
            InitializeComponent();
        }

        private void Graficar(int ancho, int alto, Graphics g, double xi, double xf)
        {
            ci = 1; cf = ancho;
            fi = 1; ff = alto;
            this.xi = xi;
            this.xf = xf;
            n = cf - ci;
            h = (xf - xi) / n;
            yi = yf = 0;
            for (int i = 1; i < n; i++)
            {
                x = xi + i * h;
                y = Fu(x);
                if (y < yi) yi = y;
                if (y > yf) yf = y;
            }

            int c1, f1;
            x = xi;
            y = Fu(x);
            c1 = Col();
            f1 = Fil();
            for (int k = 1; k <= n; k++)
            {
                x = xi + k * h;
                y = Fu(x);
                c = Col();
                f = Fil();
                g.DrawLine(Pens.Black, c1, f1, c, f);
                c1 = c;
                f1 = f;
            }
        }

        double Fu(double x)
        {
            double y;
            y = Math.Cos(x);
            return (y);
        }

        int Col()
        {
            int co;
            co = (int)((x - xi) / (xf - xi) * (cf) + (xf - x) / (xf - xi) * (ci));
            return (co);
        }

        int Fil()
        {
            int fila;
            fila = (int)((y - yi) / (yf - yi) * (fi) + (yf - y) / (yf - yi) * (ff));
            return (fila);
        }

        private void Firma_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Practica1.exe");   
        }

        private void Graficando_Click(object sender, EventArgs e)
        {
            double xi, xf;
            int an, al;
            xi = double.Parse(Xi.Text);
            xf = double.Parse(Xf.Text);
            Graphics g = pic1.CreateGraphics();
            an = pic1.Width;
            al = pic1.Height;

            Graficadora graf = new Graficadora();
            graf.Graficar(an, al, g, xi, xf);
        }

        private void Borrar_Click(object sender, EventArgs e)
        {
            pic1.Refresh();  
        }
    }
}
