using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using GalyaFieldsMath;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Printing;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;

namespace GalyaFieldsDesktop
{
    public partial class Form1 : Form
    {
        ApplicationContext db = new ApplicationContext();
        GalyaField GalyaField { get; set; }
        GalyaFieldPolinom GalyaFieldPolinom { get; set; }

        //GalyaMain GF2 = new GalyaMain(2);
        ////int[] arr = new int[4] { 1, 1, 0, 1 };
        ////int[] array2 = [1, 2, 3, 4, 5, 6];

        //GalyaField GF8 = new GalyaField(8, new int[8] { 1, 1, 0, 1, 0, 0, 0, 1 });
        //GalyaField GF8_1 = new GalyaField(8, new int[8] { 3, 4, 0, 7, 0, 0, 0, 0 });

        //GalyaField GF8_2 = new GalyaField(8, new int[8] { 1, 1, 0, 1, 0, 0, 0, 1 });
        //GalyaField GF8_3 = new GalyaField(8, new int[8] { 3, 4, 0, 7, 0, 0, 0, 0 });

        //GalyaField GF8_4 = new GalyaField(8, new int[3] { 1, 1, 1 });
        //GalyaField GF8_5 = new GalyaField(8, new int[2] { 1, 1 });

        //static int[][] numbers = new int[2][]{
        //     new int[] { 1, 0 },
        //     new int[] { 1, 0 },
        //};
        //GalyaFieldPolinom GF4 = new GalyaFieldPolinom(2, 2, new int[3] { 1, 1, 1 }, numbers);

        //static int[][] numbers1 = new int[3][]{
        //     new int[] { 1, 1 },
        //     new int[] { 1, 1 },
        //     new int[] { 1, 1 },
        //};
        //GalyaFieldPolinom GF4_1 = new GalyaFieldPolinom(2, 2, new int[3] { 1, 1, 1 }, numbers1);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            comboBox1.SelectedIndex = 0;
            //richTextBox1.Text= GF2.print();
            //richTextBox1.Text += GF8.print();
            //richTextBox1.Text += GF4.print();

            //richTextBox1.Text += (GF8 + GF8_1).print();
            //richTextBox1.Text += (GF8_2 - GF8_3).print();

            //richTextBox1.Text += (-GF8_1).print();
            //richTextBox1.Text += (GF8 * GF8_1).print();

            //richTextBox1.Text += (GF8_4 / GF8_5).print();

            //int[] k = GF8_5.findRoots();
            //for (int i = 0; i < k.Length; i++)
            //{
            //    richTextBox1.Text += k[i] + "  ";
            //}

            //richTextBox1.Text += GF4.print();

            //richTextBox1.Text += (GF4-GF4).print();

            //richTextBox1.Text += GF4.print() + (GF4 * GF4).print();
            //richTextBox1.Text += isSimple(5);
            //richTextBox1.Text += GF4_1.print() + (GF4_1 / GF4).print();

            //richTextBox1.Text += (GF4_1 + GF4).print();
            //richTextBox1.Text += GF4.print();

            //richTextBox1.Text += '\r';
            //int[][] k = GF4.findRoots();
            //for (int i = 0; i < k.Length; i++)
            //{
            //    for (int j = 0; j < 2; j++)
            //    {
            //        richTextBox1.Text += k[i][j] + " ";
            //    }
            //    richTextBox1.Text += '\r';
            //}

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == (char)8) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //private void textBox2_3_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if ((e.KeyChar >= '0') && (e.KeyChar <= '9') || char.IsControl(e.KeyChar) || (e.KeyChar == '-') || (e.KeyChar == '+') || (e.KeyChar == '^') || (e.KeyChar == 'X') || (e.KeyChar == 'x'))
        //    {
        //        if(e.KeyChar == '^' && (textBox2.Text.Last() != 'x' || textBox2.Text.Last() != 'x')) { }
        //        return;
        //    }
        //    e.Handled = true;
        //}

        private void textBox2KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    if ((e.KeyChar >= '0') && (e.KeyChar <= '9') || char.IsControl(e.KeyChar) || (e.KeyChar == '-') || (e.KeyChar == '+') || (e.KeyChar == '^') || (e.KeyChar == 'X') || (e.KeyChar == 'x'))
                    {
                        return;
                    }
                    e.Handled = true;
                    break;

                case 1:
                    if ((e.KeyChar >= '0') && (e.KeyChar <= '9') || char.IsControl(e.KeyChar) || (e.KeyChar == '-') || (e.KeyChar == '+') || (e.KeyChar == '^') || (e.KeyChar == 'X') || (e.KeyChar == 'x') || (e.KeyChar == 'a'))
                    {
                        return;
                    }
                    e.Handled = true;
                    break;
            }
        }
        private void textBox3KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    if ((e.KeyChar >= '0') && (e.KeyChar <= '9') || char.IsControl(e.KeyChar) || (e.KeyChar == '-') || (e.KeyChar == '+') || (e.KeyChar == '^') || (e.KeyChar == 'X') || (e.KeyChar == 'x'))
                    {
                        return;
                    }
                    e.Handled = true;
                    break;

                case 1:
                    if ((e.KeyChar >= '0') && (e.KeyChar <= '9') || char.IsControl(e.KeyChar) || (e.KeyChar == '-') || (e.KeyChar == '+') || (e.KeyChar == '^') || (e.KeyChar == 'X') || (e.KeyChar == 'x') || (e.KeyChar == 'a'))
                    {
                        return;
                    }
                    e.Handled = true;
                    break;
            }
        }
        private void textBox5KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9') || char.IsControl(e.KeyChar) || (e.KeyChar == '-') || (e.KeyChar == '+') || (e.KeyChar == '^') || (e.KeyChar == 'X') || (e.KeyChar == 'x'))
            {
                //if (e.KeyChar == '^' && (textBox3.Text.Last() != 'x' || textBox3.Text.Last() != 'X')) { }
                return;
            }
            e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для использования калькулятора в полях Галуа вам необходимо:" +
                "\n1)Ввести основание поля\n2)для нахождения корней полинома или значения полинома в точке ввести полином1\n" +
                "3)для произведения операций над многочленами ввести оба многочлена, после чего нажать на кнопки математических операций\n" +
                "4)для произведения операций в поле GF(p^n) поменять тип поля в comboBox после чего ввести степень поля и порождающий многочлен\n" +
                "5)в случае надобности допускается ввод значений в поля из файла, но тогда они должны быть правильно расположены (каждое новое на своей строчке и не больше количества ячеек для ввода)\n" +
                "6)калькулятор позволяет работать в несколько этапов, через верхнее меню (файл) можно сохранять и открывать txt файлы с историей вычислений, а также печатать вычисления\n" +
                "7)для ускорения работы вы можете сохранять данные о построении элементов поля GF(p^n) в базу данных"
                );
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Text != string.Empty)
                if (isSimple(Convert.ToInt32(numericUpDown1.Text)))
                {
                    if (textBox2.Text == string.Empty)
                    {
                        MessageBox.Show("введите полином 1");
                        textBox2.Focus();
                        textBox2.SelectAll();
                        return;
                    }
                    if (textBox3.Text == string.Empty)
                    {
                        MessageBox.Show("введите полином 2");
                        textBox3.Focus();
                        textBox3.SelectAll();
                        return;
                    }
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            if (isPolinomRightTB2(textBox2.Text))
                            {
                                int[] Polinom = GetPolinom(textBox2.Text);
                                if (isPolinomRightTB3(textBox3.Text))
                                {
                                    int[] Polinom2 = GetPolinom(textBox3.Text);
                                    GalyaField GF = new GalyaField(Convert.ToInt32(numericUpDown1.Text), Polinom);
                                    GalyaField GFx = new GalyaField(Convert.ToInt32(numericUpDown1.Text), Polinom2);
                                    richTextBox1.Text += $"GF({Convert.ToInt32(numericUpDown1.Text)})\r";
                                    //придумать как выводить 0 и нет корней
                                    ////if ((GF + GFx).getPolinom() != null)

                                    //richTextBox1.Text += (GFx + GF).print();
                                    //else
                                    //    richTextBox1.Text = "0\r";

                                    richTextBox1.Text += "(" + textBox2.Text + ") + (" + textBox3.Text + ") = " + (GF + GFx).printPolinom();
                                    richTextBox1.Text += "\r";
                                    richTextBox1.Select(richTextBox1.Text.Length, 0);
                                    richTextBox1.ScrollToCaret();
                                    break;
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                return;
                            }
                            break;
                        case 1:
                            if (textBox5.Text == string.Empty)
                            {
                                MessageBox.Show("введите порождающий полином");
                                textBox5.Focus();
                                textBox5.SelectAll();
                                return;
                            }
                            if (Convert.ToInt32(numericUpDown2.Text) < 2)
                            {
                                MessageBox.Show("степень должна быть не меньше 2");
                                numericUpDown2.Focus();
                                numericUpDown2.Select(0, numericUpDown2.Text.Length);
                                break;
                            }
                            if (!isPolinomRightTB4(textBox5.Text)) return;
                            if (!isPolinomRightTB2(textBox2.Text)) return;
                            if (!isPolinomRightTB3(textBox3.Text)) return;
                            int[]GenPolinom = GetPolinom(textBox5.Text);
                            if(GenPolinom.Length != Convert.ToInt32(numericUpDown2.Text) + 1)
                            {
                                MessageBox.Show("степень порождающего многочлена должна быть равна степени основания поля");
                                textBox5.Focus();
                                textBox5.Select(0, textBox5.Text.Length);
                                return;
                            }
                            int[][] Polinom11 = (int[][])getAPolinom(textBox2.Text).Clone();
                            int[][] Polinom21 = getAPolinom(textBox3.Text);
                            GalyaFieldPolinom GFprobe = new GalyaFieldPolinom(Convert.ToInt32(numericUpDown1.Text), Convert.ToInt32(numericUpDown2.Text), GenPolinom);

                            int[][] a1 = GFprobe.getField();
                            for (int i = 0; i < a1.Length; i++)
                            {
                                if (a1[i] == null)
                                {
                                    MessageBox.Show("по данному многочлену не построить поле с примитивным элементом a");
                                    textBox5.Focus();
                                    textBox5.Select(0, textBox5.Text.Length);
                                    return;
                                }
                            }
                            richTextBox1.Text += $"GF({Convert.ToInt32(numericUpDown1.Text)}^{Convert.ToInt32(numericUpDown2.Text)})\r";
                            int[][] Pol = new int[Polinom11.Length][];
                            for (int i = 0; i < Polinom11.Length; i++)
                            {
                                Pol[i] = (int[])GFprobe.getFieldUnit(Polinom11[i][1], Polinom11[i][0]).Clone();
                            }
                            GalyaFieldPolinom GF1 = new GalyaFieldPolinom(Convert.ToInt32(numericUpDown1.Text), Convert.ToInt32(numericUpDown2.Text), GenPolinom, Pol);
                            int[][] Pol1 = new int[Polinom21.Length][];
                            GalyaFieldPolinom GFprobe1 = new GalyaFieldPolinom(Convert.ToInt32(numericUpDown1.Text), Convert.ToInt32(numericUpDown2.Text), GenPolinom);

                            int[][] a2 = GFprobe1.getField();
                            for (int i = 0; i < a2.Length; i++)
                            {
                                if (a2[i] == null)
                                {
                                    MessageBox.Show("по данному многочлену не построить поле с примитивным элементом a");
                                    textBox5.Focus();
                                    textBox5.Select(0, textBox5.Text.Length);
                                    return;
                                }
                            }
                            for (int i = 0; i < Polinom21.Length; i++)
                            {
                                Pol1[i] = (int[])GFprobe1.getFieldUnit(Polinom21[i][1], Polinom21[i][0]).Clone();
                            }
                            GalyaFieldPolinom GFx1 = new GalyaFieldPolinom(Convert.ToInt32(numericUpDown1.Text), Convert.ToInt32(numericUpDown2.Text), GenPolinom, Pol1);
                            //if ((GF1 + GFx1).getPolinom().Length != null)
                            //   richTextBox1.Text += (GF1 + GFx1).print();
                            // else
                            //    richTextBox1.Text = "0\r";

                            richTextBox1.Text += "(" + textBox2.Text + ") + (" + textBox3.Text + ") = " + (GF1 + GFx1).printPolinom();
                            richTextBox1.Text += "\r";
                            richTextBox1.Select(richTextBox1.Text.Length, 0);
                            richTextBox1.ScrollToCaret();
                            break;
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("основание должно быть простым числом большим 1");
                    numericUpDown1.Focus();
                    numericUpDown1.Select(0, numericUpDown1.Text.Length);
                }
        }
        //не работает перевод полинома для создания поля


        private void button3_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Text != string.Empty)
                if (isSimple(Convert.ToInt32(numericUpDown1.Text)))
                {
                    if (textBox2.Text == string.Empty)
                    {
                        MessageBox.Show("введите полином 1");
                        textBox2.Focus();
                        textBox2.SelectAll();
                        return;
                    }
                    if (textBox3.Text == string.Empty)
                    {
                        MessageBox.Show("введите полином 2");
                        textBox3.Focus();
                        textBox3.SelectAll();
                        return;
                    }
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            if (isPolinomRightTB2(textBox2.Text))
                            {
                                int[] Polinom = GetPolinom(textBox2.Text);
                                if (isPolinomRightTB3(textBox3.Text))
                                {
                                    int[] Polinom2 = GetPolinom(textBox3.Text);
                                    GalyaField GF = new GalyaField(Convert.ToInt32(numericUpDown1.Text), Polinom);
                                    GalyaField GFx = new GalyaField(Convert.ToInt32(numericUpDown1.Text), Polinom2);
                                    richTextBox1.Text += $"GF({Convert.ToInt32(numericUpDown1.Text)})\r";
                                    //if ((GF - GFx).getPolinom().Length != null)
                                    //    richTextBox1.Text += (GF - GFx).print();
                                    //else
                                    //    richTextBox1.Text = "0\r";

                                    richTextBox1.Text += "(" + textBox2.Text + ") - (" + textBox3.Text + ") = " + (GF - GFx).printPolinom();
                                    richTextBox1.Text += "\r";
                                    richTextBox1.Select(richTextBox1.Text.Length, 0);
                                    richTextBox1.ScrollToCaret();
                                    break;
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                return;
                            }
                            break;
                        case 1:
                            if (Convert.ToInt32(numericUpDown2.Text) < 2)
                            {
                                MessageBox.Show("степень должна быть не меньше 2");
                                numericUpDown2.Focus();
                                numericUpDown2.Select(0, numericUpDown2.Text.Length);
                                break;
                            }
                            if (textBox5.Text == string.Empty)
                            {
                                MessageBox.Show("введите порождающий полином");
                                textBox5.Focus();
                                textBox5.SelectAll();
                                return;
                            }
                            if (!isPolinomRightTB4(textBox5.Text)) return;
                            if (!isPolinomRightTB2(textBox2.Text)) return;
                            if (!isPolinomRightTB3(textBox3.Text)) return;
                            int[] GenPolinom = GetPolinom(textBox5.Text);
                            if (GenPolinom.Length != Convert.ToInt32(numericUpDown2.Text) + 1)
                            {
                                MessageBox.Show("степень порождающего многочлена должна быть равна степени основания поля");
                                textBox5.Focus();
                                textBox5.Select(0, textBox5.Text.Length);
                                return;
                            }
                            int[][] Polinom11 = (int[][])getAPolinom(textBox2.Text).Clone();
                            int[][] Polinom21 = getAPolinom(textBox3.Text);
                            GalyaFieldPolinom GFprobe = new GalyaFieldPolinom(Convert.ToInt32(numericUpDown1.Text), Convert.ToInt32(numericUpDown2.Text), GenPolinom);

                            int[][] a1 = GFprobe.getField();
                            for (int i = 0; i < a1.Length; i++)
                            {
                                if (a1[i] == null)
                                {
                                    MessageBox.Show("по данному многочлену не построить поле с примитивным элементом a");
                                    textBox5.Focus();
                                    textBox5.Select(0, textBox5.Text.Length);
                                    return;
                                }
                            }
                            richTextBox1.Text += $"GF({Convert.ToInt32(numericUpDown1.Text)}^{Convert.ToInt32(numericUpDown2.Text)})\r";
                            int[][] Pol = new int[Polinom11.Length][];
                            for (int i = 0; i < Polinom11.Length; i++)
                            {
                                Pol[i] = (int[])GFprobe.getFieldUnit(Polinom11[i][1], Polinom11[i][0]).Clone();
                            }
                            GalyaFieldPolinom GF1 = new GalyaFieldPolinom(Convert.ToInt32(numericUpDown1.Text), Convert.ToInt32(numericUpDown2.Text), GenPolinom, Pol);
                            int[][] Pol1 = new int[Polinom21.Length][];
                            GalyaFieldPolinom GFprobe1 = new GalyaFieldPolinom(Convert.ToInt32(numericUpDown1.Text), Convert.ToInt32(numericUpDown2.Text), GenPolinom);

                            int[][] a2 = GFprobe1.getField();
                            for (int i = 0; i < a2.Length; i++)
                            {
                                if (a2[i] == null)
                                {
                                    MessageBox.Show("по данному многочлену не построить поле с примитивным элементом a");
                                    textBox5.Focus();
                                    textBox5.Select(0, textBox5.Text.Length);
                                    return;
                                }
                            }
                            for (int i = 0; i < Polinom21.Length; i++)
                            {
                                Pol1[i] = (int[])GFprobe1.getFieldUnit(Polinom21[i][1], Polinom21[i][0]).Clone();
                            }
                            GalyaFieldPolinom GFx1 = new GalyaFieldPolinom(Convert.ToInt32(numericUpDown1.Text), Convert.ToInt32(numericUpDown2.Text), GenPolinom, Pol1);
                            //if ((GF1 - GFx1).getPolinom().Length != null)
                            //  richTextBox1.Text += (GF1 - GFx1).print();
                            // else
                            //richTextBox1.Text = "0\r";

                            richTextBox1.Text += "(" + textBox2.Text + ") - (" + textBox3.Text + ") = " + (GF1 - GFx1).printPolinom();
                            richTextBox1.Text += "\r";
                            richTextBox1.Select(richTextBox1.Text.Length, 0);
                            richTextBox1.ScrollToCaret();
                            break;
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("основание должно быть простым числом большим 1");
                    numericUpDown1.Focus();
                    numericUpDown1.Select(0, numericUpDown1.Text.Length);
                }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Text != string.Empty)
                if (isSimple(Convert.ToInt32(numericUpDown1.Text)))
                {
                    if (textBox2.Text == string.Empty)
                    {
                        MessageBox.Show("введите полином 1");
                        textBox2.Focus();
                        textBox2.SelectAll();
                        return;
                    }
                    if (textBox3.Text == string.Empty)
                    {
                        MessageBox.Show("введите полином 2");
                        textBox3.Focus();
                        textBox3.SelectAll();
                        return;
                    }
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            if (isPolinomRightTB2(textBox2.Text))
                            {
                                int[] Polinom = GetPolinom(textBox2.Text);
                                if (isPolinomRightTB3(textBox3.Text))
                                {
                                    int[] Polinom2 = GetPolinom(textBox3.Text);
                                    GalyaField GF = new GalyaField(Convert.ToInt32(numericUpDown1.Text), Polinom);
                                    GalyaField GFx = new GalyaField(Convert.ToInt32(numericUpDown1.Text), Polinom2);
                                    richTextBox1.Text += $"GF({Convert.ToInt32(numericUpDown1.Text)})\r";
                                    //if ((GF * GFx).getPolinom().Length != null)
                                    //    richTextBox1.Text += (GF * GFx).print();
                                    //else
                                    //    richTextBox1.Text = "0\r";

                                    richTextBox1.Text += "(" + textBox2.Text + ") * (" + textBox3.Text + ") = " + (GF * GFx).printPolinom();
                                    richTextBox1.Text += "\r";
                                    richTextBox1.Select(richTextBox1.Text.Length, 0);
                                    richTextBox1.ScrollToCaret();
                                    break;
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                return;
                            }
                            break;
                        case 1:
                            if (Convert.ToInt32(numericUpDown2.Text) < 2)
                            {
                                MessageBox.Show("степень должна быть не меньше 2");
                                numericUpDown2.Focus();
                                numericUpDown2.Select(0, numericUpDown2.Text.Length);
                                break;
                            }
                            if (textBox5.Text == string.Empty)
                            {
                                MessageBox.Show("введите порождающий полином");
                                textBox5.Focus();
                                textBox5.SelectAll();
                                return;
                            }
                            if (!isPolinomRightTB4(textBox5.Text)) return;
                            if (!isPolinomRightTB2(textBox2.Text)) return;
                            if (!isPolinomRightTB3(textBox3.Text)) return;
                            int[] GenPolinom = GetPolinom(textBox5.Text);
                            if (GenPolinom.Length != Convert.ToInt32(numericUpDown2.Text) + 1)
                            {
                                MessageBox.Show("степень порождающего многочлена должна быть равна степени основания поля");
                                textBox5.Focus();
                                textBox5.Select(0, textBox5.Text.Length);
                                return;
                            }
                            int[][] Polinom11 = (int[][])getAPolinom(textBox2.Text).Clone();
                            int[][] Polinom21 = getAPolinom(textBox3.Text);
                            GalyaFieldPolinom GFprobe = new GalyaFieldPolinom(Convert.ToInt32(numericUpDown1.Text), Convert.ToInt32(numericUpDown2.Text), GenPolinom);

                            int[][] a1 = GFprobe.getField();
                            for (int i = 0; i < a1.Length; i++)
                            {
                                if (a1[i] == null)
                                {
                                    MessageBox.Show("по данному многочлену не построить поле с примитивным элементом a");
                                    textBox5.Focus();
                                    textBox5.Select(0, textBox5.Text.Length);
                                    return;
                                }
                            }
                            richTextBox1.Text += $"GF({Convert.ToInt32(numericUpDown1.Text)}^{Convert.ToInt32(numericUpDown2.Text)})\r";
                            int[][] Pol = new int[Polinom11.Length][];
                            for (int i = 0; i < Polinom11.Length; i++)
                            {
                                Pol[i] = (int[])GFprobe.getFieldUnit(Polinom11[i][1], Polinom11[i][0]).Clone();
                            }
                            GalyaFieldPolinom GF1 = new GalyaFieldPolinom(Convert.ToInt32(numericUpDown1.Text), Convert.ToInt32(numericUpDown2.Text), GenPolinom, Pol);
                            int[][] Pol1 = new int[Polinom21.Length][];
                            GalyaFieldPolinom GFprobe1 = new GalyaFieldPolinom(Convert.ToInt32(numericUpDown1.Text), Convert.ToInt32(numericUpDown2.Text), GenPolinom);

                            int[][] a2 = GFprobe1.getField();
                            for (int i = 0; i < a2.Length; i++)
                            {
                                if (a2[i] == null)
                                {
                                    MessageBox.Show("по данному многочлену не построить поле с примитивным элементом a");
                                    textBox5.Focus();
                                    textBox5.Select(0, textBox5.Text.Length);
                                    return;
                                }
                            }
                            for (int i = 0; i < Polinom21.Length; i++)
                            {
                                Pol1[i] = (int[])GFprobe1.getFieldUnit(Polinom21[i][1], Polinom21[i][0]).Clone();
                            }
                            GalyaFieldPolinom GFx1 = new GalyaFieldPolinom(Convert.ToInt32(numericUpDown1.Text), Convert.ToInt32(numericUpDown2.Text), GenPolinom, Pol1);
                            //if ((GF1 * GFx1).getPolinom().Length != null)
                            // richTextBox1.Text += (GF1 * GFx1).print();
                            // else
                            //   richTextBox1.Text = "0\r";
                            richTextBox1.Text += "(" + textBox2.Text + ") * (" + textBox3.Text + ") = " + (GF1 * GFx1).printPolinom();
                            richTextBox1.Text += "\r";
                            richTextBox1.Select(richTextBox1.Text.Length, 0);
                            richTextBox1.ScrollToCaret();
                            break;
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("основание должно быть простым числом большим 1");
                    numericUpDown1.Focus();
                    numericUpDown1.Select(0, numericUpDown1.Text.Length);
                }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Text != string.Empty)
                if (isSimple(Convert.ToInt32(numericUpDown1.Text)))
                {
                    if (textBox2.Text == string.Empty)
                    {
                        MessageBox.Show("введите полином 1");
                        textBox2.Focus();
                        textBox2.SelectAll();
                        return;
                    }
                    if (textBox3.Text == string.Empty)
                    {
                        MessageBox.Show("введите полином 2");
                        textBox3.Focus();
                        textBox3.SelectAll();
                        return;
                    }
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            if (isPolinomRightTB2(textBox2.Text))
                            {
                                int[] Polinom = GetPolinom(textBox2.Text);
                                if (isPolinomRightTB3(textBox3.Text))
                                {
                                    int[] Polinom2 = GetPolinom(textBox3.Text);
                                    GalyaField GF = new GalyaField(Convert.ToInt32(numericUpDown1.Text), Polinom);
                                    GalyaField GFx = new GalyaField(Convert.ToInt32(numericUpDown1.Text), Polinom2);
                                    richTextBox1.Text += $"GF({Convert.ToInt32(numericUpDown1.Text)})\r";
                                    //if ((GF / GFx).getPolinom().Length != null)
                                    //    richTextBox1.Text += (GF / GFx).print();
                                    //else
                                    //    richTextBox1.Text = "0\r";

                                    richTextBox1.Text += "(" + textBox2.Text + ") / (" + textBox3.Text + ") = " + (GF / GFx).printPolinom();
                                    richTextBox1.Text += "\r";
                                    richTextBox1.Select(richTextBox1.Text.Length, 0);
                                    richTextBox1.ScrollToCaret();
                                    break;
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                return;
                            }
                            break;
                        case 1:
                            if (Convert.ToInt32(numericUpDown2.Text) < 2)
                            {
                                MessageBox.Show("степень должна быть не меньше 2");
                                numericUpDown2.Focus();
                                numericUpDown2.Select(0, numericUpDown2.Text.Length);
                                break;
                            }
                            if (textBox5.Text == string.Empty)
                            {
                                MessageBox.Show("введите порождающий полином");
                                textBox5.Focus();
                                textBox5.SelectAll();
                                return;
                            }
                            if (!isPolinomRightTB4(textBox5.Text)) return;
                            if (!isPolinomRightTB2(textBox2.Text)) return;
                            if (!isPolinomRightTB3(textBox3.Text)) return;
                            int[] GenPolinom = GetPolinom(textBox5.Text);
                            if (GenPolinom.Length != Convert.ToInt32(numericUpDown2.Text) + 1)
                            {
                                MessageBox.Show("степень порождающего многочлена должна быть равна степени основания поля");
                                textBox5.Focus();
                                textBox5.Select(0, textBox5.Text.Length);
                                return;
                            }
                            int[][] Polinom11 = (int[][])getAPolinom(textBox2.Text).Clone();
                            int[][] Polinom21 = getAPolinom(textBox3.Text);
                            GalyaFieldPolinom GFprobe = new GalyaFieldPolinom(Convert.ToInt32(numericUpDown1.Text), Convert.ToInt32(numericUpDown2.Text), GenPolinom);

                            int[][] a1 = GFprobe.getField();
                            for (int i = 0; i < a1.Length; i++)
                            {
                                if (a1[i] == null)
                                {
                                    MessageBox.Show("по данному многочлену не построить поле с примитивным элементом a");
                                    textBox5.Focus();
                                    textBox5.Select(0, textBox5.Text.Length);
                                    return;
                                }
                            }
                            richTextBox1.Text += $"GF({Convert.ToInt32(numericUpDown1.Text)}^{Convert.ToInt32(numericUpDown2.Text)})\r";
                            int[][] Pol = new int[Polinom11.Length][];
                            for (int i = 0; i < Polinom11.Length; i++)
                            {
                                Pol[i] = (int[])GFprobe.getFieldUnit(Polinom11[i][1], Polinom11[i][0]).Clone();
                            }
                            GalyaFieldPolinom GF1 = new GalyaFieldPolinom(Convert.ToInt32(numericUpDown1.Text), Convert.ToInt32(numericUpDown2.Text), GenPolinom, Pol);
                            int[][] Pol1 = new int[Polinom21.Length][];
                            GalyaFieldPolinom GFprobe1 = new GalyaFieldPolinom(Convert.ToInt32(numericUpDown1.Text), Convert.ToInt32(numericUpDown2.Text), GenPolinom);

                            int[][] a2 = GFprobe1.getField();
                            for (int i = 0; i < a2.Length; i++)
                            {
                                if (a2[i] == null)
                                {
                                    MessageBox.Show("по данному многочлену не построить поле с примитивным элементом a");
                                    textBox5.Focus();
                                    textBox5.Select(0, textBox5.Text.Length);
                                    return;
                                }
                            }
                            for (int i = 0; i < Polinom21.Length; i++)
                            {
                                Pol1[i] = (int[])GFprobe1.getFieldUnit(Polinom21[i][1], Polinom21[i][0]).Clone();
                            }
                            GalyaFieldPolinom GFx1 = new GalyaFieldPolinom(Convert.ToInt32(numericUpDown1.Text), Convert.ToInt32(numericUpDown2.Text), GenPolinom, Pol1);
                           

                            richTextBox1.Text += "(" + textBox2.Text + ") / (" + textBox3.Text + ") = " + (GF1 / GFx1).printPolinom();
                            richTextBox1.Text += "\r";
                            richTextBox1.Select(richTextBox1.Text.Length, 0);
                            richTextBox1.ScrollToCaret();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("основание должно быть простым числом большим 1");
                    numericUpDown1.Focus();
                    numericUpDown1.Select(0, numericUpDown1.Text.Length);
                }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (numericUpDown1.Text != string.Empty)
                    if (isSimple(Convert.ToInt32(numericUpDown1.Text)))
                    {
                        if (textBox2.Text == string.Empty)
                        {
                            MessageBox.Show("введите полином 1");
                            textBox2.Focus();
                            textBox2.SelectAll();
                            return;
                        }
                        switch (comboBox1.SelectedIndex)
                        {
                            case 0:
                                if (isPolinomRightTB2(textBox2.Text))
                                {
                                    int[] Polinom = GetPolinom(textBox2.Text);
                                    //if (isPolinomRightTB2(textBox3.Text))
                                    //{
                                    //int[] Polinom2 = GetPolinom(textBox3.Text);
                                    GalyaField GF = new GalyaField(Convert.ToInt32(numericUpDown1.Text), Polinom);
                                    richTextBox1.Text += $"GF({Convert.ToInt32(numericUpDown1.Text)})\r";
                                    richTextBox1.Text += $"{textBox2.Text} = 0\r";
                                    //GalyaField GFx = new GalyaField(Convert.ToInt32(numericUpDown1.Text), Polinom2);
                                    int[] b = GF.findRoots();
                                    if (b.Length == 0)
                                    {
                                        richTextBox1.Text += "корней нет\r";
                                    }
                                    else
                                    {
                                        richTextBox1.Text += "{";
                                        for (int i = 0; i < b.Length; i++)
                                        {

                                            richTextBox1.Text += b[i] + ", ";
                                        }
                                        richTextBox1.Text = richTextBox1.Text.TrimEnd(' ');
                                        richTextBox1.Text = richTextBox1.Text.TrimEnd(',');
                                        richTextBox1.Text += "}";
                                    }
                                    richTextBox1.Text += "\r";
                                    richTextBox1.Select(richTextBox1.Text.Length, 0);
                                    richTextBox1.ScrollToCaret();
                                    //}
                                    //else
                                    //{
                                    //    return;
                                    //}
                                }
                                else
                                {
                                    return;
                                }
                                break;
                            case 1:
                                if (Convert.ToInt32(numericUpDown2.Text) < 2)
                                {
                                    MessageBox.Show("степень должна быть не меньше 2");
                                    numericUpDown2.Focus();
                                    numericUpDown2.Select(0, numericUpDown2.Text.Length);
                                    break;
                                }
                                if (textBox5.Text == string.Empty)
                                {
                                    MessageBox.Show("введите порождающий полином");
                                    textBox5.Focus();
                                    textBox5.SelectAll();
                                    return;
                                }
                                if (!isPolinomRightTB4(textBox5.Text)) return;
                                if (!isPolinomRightTB2(textBox2.Text)) return;
                                //if (!isPolinomRightTB3(textBox3.Text)) return;
                                int[] GenPolinom = GetPolinom(textBox5.Text);
                                if (GenPolinom.Length != Convert.ToInt32(numericUpDown2.Text) + 1)
                                {
                                    MessageBox.Show("степень порождающего многочлена должна быть равна степени основания поля");
                                    textBox5.Focus();
                                    textBox5.Select(0, textBox5.Text.Length);
                                    return;
                                }
                                int[][] Polinom11 = (int[][])getAPolinom(textBox2.Text).Clone();
                                //int[][] Polinom21 = getAPolinom(textBox3.Text);
                                GalyaFieldPolinom GFprobe = new GalyaFieldPolinom(Convert.ToInt32(numericUpDown1.Text), Convert.ToInt32(numericUpDown2.Text), GenPolinom);
                                int[][] a1 = GFprobe.getField();
                                for (int i = 0; i < a1.Length; i++)
                                {
                                    if (a1[i] == null)
                                    {
                                        MessageBox.Show("по данному многочлену не построить поле с примитивным элементом a");
                                        textBox5.Focus();
                                        textBox5.Select(0, textBox5.Text.Length);
                                        return;
                                    }
                                }
                                richTextBox1.Text += $"GF({Convert.ToInt32(numericUpDown1.Text)}^{Convert.ToInt32(numericUpDown2.Text)})\r";

                                richTextBox1.Text += $"{textBox2.Text} = 0\r";
                                int[][] Pol = new int[Polinom11.Length][];
                                for (int i = 0; i < Polinom11.Length; i++)
                                {
                                    Pol[i] = (int[])GFprobe.getFieldUnit(Polinom11[i][1], Polinom11[i][0]).Clone();
                                }
                                GalyaFieldPolinom GF1 = new GalyaFieldPolinom(Convert.ToInt32(numericUpDown1.Text), Convert.ToInt32(numericUpDown2.Text), GenPolinom, Pol);
                                //int[][] Pol1 = new int[Polinom21.Length][];
                                //GalyaFieldPolinom GFprobe1 = new GalyaFieldPolinom(Convert.ToInt32(numericUpDown1.Text), Convert.ToInt32(numericUpDown2.Text), GenPolinom);
                                //for (int i = 0; i < Polinom21.Length; i++)
                                //{
                                //    Pol1[i] = (int[])GFprobe1.getFieldUnit(Polinom21[i][1], Polinom21[i][0]).Clone();
                                //}
                                //GalyaFieldPolinom GFx1 = new GalyaFieldPolinom(Convert.ToInt32(numericUpDown1.Text), Convert.ToInt32(numericUpDown2.Text), GenPolinom, Pol1);


                                //int[][]a = GF1.findRoots();
                                //if (a.Length == 0)
                                //    richTextBox1.Text += "корней нет\r";
                                //for (int i = 0; i < a.Length; i++)
                                //{
                                //    for (int j = 0; j < a[i].Length; j++)
                                //    {
                                //        richTextBox1.Text += a[i][j] + $"a^{a[i].Length - 1 - j}+ ";
                                //    }
                                //    richTextBox1.Text.Trim(' ');
                                //    richTextBox1.Text.Trim('+');
                                //}
                                int[] a = GF1.findRoots();
                                if (a.Length == 0)
                                    richTextBox1.Text += "корней нет\r";
                                else
                                {
                                    for (int i = 0; i < a.Length; i++)
                                    {
                                        richTextBox1.Text += "{";
                                        if (a[i] != -1)
                                        {
                                            int[] b = GF1.getFieldUnit(a[i], 1);
                                            for (int j = 0; j < b.Length; j++)
                                            {
                                                richTextBox1.Text += b[j] + $"a^{b.Length - 1 - j}+ ";
                                            }
                                            richTextBox1.Text = richTextBox1.Text.TrimEnd(' ');
                                            richTextBox1.Text = richTextBox1.Text.TrimEnd('+');
                                        }
                                        else
                                        {
                                            richTextBox1.Text += "0";
                                        }
                                        richTextBox1.Text += "}";
                                        richTextBox1.Text += "\r";
                                    }
                                }
                                richTextBox1.Select(richTextBox1.Text.Length, 0);
                                richTextBox1.ScrollToCaret();
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("основание должно быть простым числом большим 1");
                        numericUpDown1.Focus();
                        numericUpDown1.Select(0, numericUpDown1.Text.Length);
                    }
            }
            catch(OverflowException ex)
            {
                MessageBox.Show("значение получилось слишком большим, невозможно обработать");
            }
        }

        public int[] GetPolinom(string str1)
        {
            //switch (comboBox1.SelectedIndex)
            //{
            //    case 0:
                    string prov = "xX+-^";
            int d = 0;
                    for (int i = 0; i < str1.Length; i++)
                    {
                if (str1[i] == '^') d = 1;
                        if (str1[i] == 'X' || str1[i] == 'x')
                        {
                            for (int j = 0; j < prov.Length; j++)
                            {
                                if (i == 0)
                                {
                                    str1 = str1.Insert(i, "1");
                                    i++;
                                    break;
                                }
                                else if (str1[i - 1] == prov[j])
                                {
                                    str1 = str1.Insert(i, "1");
                                    i++;
                                    break;
                                }
                            }
                        }
                        if (str1[i] == 'X' || str1[i] == 'x')
                        {
                            if (i + 1 == str1.Length)
                            {
                                str1 += "^1";
                                break;
                            }
                            else if (str1[i + 1] != '^')
                            {
                                str1 = str1.Insert(i + 1, "^1");
                        d = 1;
                                i += 2;
                            }
                        }
                if (str1[i] <= '9' && str1[i] >= '0' && d == 0)
                {
                    if (i + 1 < str1.Length)
                    {
                        if (str1[i + 1] == 'x' || str1[i + 1] == 'X') goto exit;
                        else while (str1[i] <= '9' && str1[i] >= '0' && i + 1 < str1.Length)
                            {
                                if (str1[i + 1] == 'x' || str1[i + 1] == 'X') goto exit;
                                i++;
                            }
                    }
                    str1 = str1.Insert(i + 1, "x^0");
                    i += 3;
                }exit:;
                if (str1[i] == '+' || str1[i] == '-') d = 0;
                    }
                    //дописать для проверки на степень больше 9 в конце строки
                    //if ((str1.Last() < '9' && str1.Last() > '0') && str1[str1.Length-2]!='^') str1 += "X^0";
                    //int k = 0, l = 1, g = 1;
        //смотри конец строки
                //    int g = 1;
                //flag:;
                //    if (str1.Length - g != -1)
                //    {
                //        if (str1[str1.Length - g] < '9' && str1[str1.Length - g] > '0')
                //        {
                //            g++;
                //            goto flag;
                //        }
                //    }
                //    else
                //    {
                //        g--;
                //    }
                //    if (str1[str1.Length - g] != '^') str1 += "X^0";
                    //richTextBox1.Text += str1;
                    MatchCollection numbers = Regex.Matches(str1, @"[+-]\d+|\d+");

                    int[] koeff = new int[0];
                    int[] stepen = new int[0];
                    int f, l, t = 0;
                    foreach (Match match in numbers)
                    {
                        if (t % 2 == 0)
                        {
                            Array.Resize(ref koeff, koeff.Length + 1);
                            Int32.TryParse(match.ToString(), out f);
                            koeff[t / 2] = f;
                        }
                        else
                        {
                            Array.Resize(ref stepen, stepen.Length + 1);
                            Int32.TryParse(match.ToString(), out l);
                            stepen[t / 2] = l;
                        }
                        t++;
                    }
                    //for (int i = 0; i < koeff.Length; i++)
                    //{
                    //    richTextBox1.Text += "\r\n" + koeff[i] + "   " + stepen[i];

                    //}
                    int[] Polinom = new int[stepen.Max() + 1];
            //richTextBox1.Text += str1 + '\r';
            //for (int i = 0; i < koeff.Length; i++)
            //{
            //    richTextBox1.Text += koeff[i] + " " + stepen[i] + '\r';
            //}
                    for (int i = 0; i < stepen.Length; i++)
                    {
                        Polinom[Polinom.Length - stepen[i] - 1] += koeff[i];
                    }


                    return Polinom;
                   // break;
                //case 1:
                    //из след функции
                   // break;
           // }
           // return new int[0];
        }
        
        //принято решение получать массив 2*x
        //не работают дописки a
        public int[][]getAPolinom(string str1)
        {
            string prov1 = "xX+-^";
            int d = 0;
            if (str1[str1.Length - 1] == 'x' || str1[str1.Length - 1] == 'X') str1 = str1.Insert(str1.Length, "^1");
            for (int i = 0; i < str1.Length; i++)
            {
                if (i == 0 && str1[i] == 'x' || str1[i] == 'X') str1 = str1.Insert(0, "1a^0");
                if (i + 1 != str1.Length)
                {
                    if ((str1[i] == 'x' || str1[i] == 'X') && str1[i + 1] == '^') i++;
                }
                if (str1[i] == '^')
                {
                    d = 1; 
                    i++;
                }
                if (str1[i] == '+' || str1[i] == '-')
                {
                    d = 0;
                    i++;
                }
                //if ((str1[i] == 'X' || str1[i] == 'x') && d == 0)
                //{
                //    str1 = str1.Insert(i, "1a^0");
                //    i += 4;
                //}
                if(i + 1 != str1.Length)
                if ((str1[i] == 'X' || str1[i] == 'x') && d == 1 && str1[i+1]!='^')
                {
                    str1 = str1.Insert(i+1, "^1");
                    i += 2;
                }
                if (str1[i] == 'X' || str1[i] == 'x')
                {
                    for (int j = 0; j < prov1.Length; j++)
                    {
                        if (i == 0)
                        {
                            str1 = str1.Insert(i, "1a^0");
                            i += 4;
                            break;
                        }
                        else if (str1[i - 1] == prov1[j])
                        {
                            str1 = str1.Insert(i, "1a^0");
                            i += 4;
                            break;
                        }
                    }
                }
                //if(i>0)
                //if (str1[i - 1] < '9' || str1[i-1]>'0')
                if(i+1 != str1.Length)
                if (str1[i] == 'X' || str1[i] == 'x' && str1[i + 1] != '^')
                {
                    if (i + 1 == str1.Length)
                    {
                        str1 += "^1";
                        break;
                    }
                    else if (str1[i + 1] == '+' || str1[i+1] == '-')
                    {
                        str1 = str1.Insert(i + 1, "^1");
                        i += 2;
                    }
                }
                if (str1[i] == 'a')
                {
                    for (int j = 0; j < prov1.Length; j++)
                    {
                        if (i == 0)
                        {
                            str1 = str1.Insert(i, "1");
                            i += 1;
                            break;
                        }
                        else if (str1[i - 1] == prov1[j])
                        {
                            str1 = str1.Insert(i, "1");
                            i += 1;
                            break;
                        }
                    }
                }
                if (str1[i] == 'a')
                {
                    if (i + 1 == str1.Length)
                    {
                        str1 += "^1";
                        break;
                    }
                    else if (str1[i + 1] != '^')
                    {
                        str1 = str1.Insert(i + 1, "^1");
                        i += 2;
                    }
                    else if (str1[i+1] == '^')
                    {
                        i++;
                        while (str1[i] <= '9' && str1[i] >= '0')
                        {
                            i++;
                        }
                    }
                    if (str1[i] == '+' || str1[i] == '-')
                    {
                        str1 = str1.Insert(i, "X^0");
                        i += 3;
                    }
                    if(i+2 <= str1.Length)
                    if (str1[i] <= '9' && str1[i] >= '0' && (str1[i+1] == 'x' || str1[i+1] == 'X') && str1[i + 2] != '^')
                    {
                            str1 = str1.Insert(i + 2, "^1");
                            i += 3;
                    }
                }
            }
            //дописать для проверки на степень больше 9 в конце строки
            //if ((str1.Last() < '9' && str1.Last() > '0') && str1[str1.Length-2]!='^') str1 += "X^0";
            //int k = 0, l = 1, g = 1;
            int g1 = 1;
        flag1:;
            if (str1.Length - g1 != -1)
            {
                if (str1[str1.Length - g1] < '9' && str1[str1.Length - g1] > '0'/* && str1[str1.Length - g1 - 1] == '^' && str1[str1.Length - g1 - 2] == '^'*/)
                {
                    g1++;
                    goto flag1;
                }
            }
            else
            {
                g1--;
            }
            if (str1[str1.Length - g1] != '^') str1 += "a^0X^0";
            if(str1[str1.Length - g1] == '^' && str1[str1.Length - g1 -1] == 'a') str1 += "X^0";
            //richTextBox1.Text += str1;
            MatchCollection numbers1 = Regex.Matches(str1, @"[+-]\d+|\d+");
           //richTextBox1.Text += str1 + '\r';
            int[] koeff1 = new int[0];
            int[] stepen1 = new int[0];
            int[] stepen2 = new int[0];
            int f1, l1, t1 = 0, k1 = 0;
            foreach (Match match in numbers1)
            {
                if (t1 % 3 == 0)
                {
                    Array.Resize(ref koeff1, koeff1.Length + 1);
                    Int32.TryParse(match.ToString(), out f1);
                    koeff1[t1 / 3] = f1;
                }
                else if(t1 % 3 == 1) 
                {
                    Array.Resize(ref stepen1, stepen1.Length + 1);
                    Int32.TryParse(match.ToString(), out l1);
                    stepen1[t1 / 3] = l1;
                }
                else
                {
                    Array.Resize(ref stepen2, stepen2.Length + 1);
                    Int32.TryParse(match.ToString(), out k1);
                    stepen2[t1 / 3] = k1;
                }
                t1++;
            }
            //for (int i = 0; i < koeff.Length; i++)
            //{
            //    richTextBox1.Text += "\r\n" + koeff[i] + "   " + stepen[i];

            //}
            int[][] Polinom1 = new int[stepen2.Max() + 1][];
            for (int i = 0; i < Polinom1.Length; i++)
            {
                Polinom1[i] = new int[2];
            }
            for (int i = 0; i < stepen2.Length; i++)
            {
                //for (int j = 0; j < Polinom1.Length; j++)
                //{
                    Polinom1[Polinom1.Length - stepen2[i] - 1][0] += koeff1[i];
                    Polinom1[Polinom1.Length - stepen2[i] - 1][1] += stepen1[i];
                //}
               // for (int j = 0; j < 2; j++)
                //{
                    //richTextBox1.Text += stepen2[i] + " " + stepen1[i] + " " + koeff1[i] + '\r';
                //}
            }

            return Polinom1;
        }
        //надо додумать перевод многочлена

        //проверка числа в texbox1 на простоту
        public bool isSimple(int a)
        {
            if (a < 2) return false;
            for (int i = 2, j = 4; j <= a; i++, j += (i << 1) - 1)
            {
                if (a % i == 0) return false;
            }
            return true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    textBox4.Visible = false; 
                    label5.Visible = false;
                    label6.Visible = false;
                    textBox5.Visible = false;
                    button7.Text = "показать элементы поля";
                    this.Width = 814;
                    this.Height = 497;
                    button7.Visible = false;
                    numericUpDown2.Visible = false;
                    checkBox1.Visible = false;
                    label7.Visible = false;
                    numericUpDown4.Visible = false;
                    break;
                case 1:
                    textBox4.Visible = true;
                    label5.Visible = true;
                    label6.Visible = true;
                    textBox5.Visible = true;
                    button7.Visible = true;
                    numericUpDown2.Visible = true;
                    label7.Visible = true;
                    numericUpDown4.Visible = true;
                    break;

            }
        }
        //вначале идет x или число
        //после ^ идут цифры, потом + или -
        //
        //
        //
        //
        public bool isPolinomRightTB2(string s)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    if (s[0] == 'x' || s[0] == 'X' || s[0] == '-' || char.IsDigit(s[0]))
                    {
                        int k = 0;
                        if (s[0] == 'x' || s[0] == 'X') k = 1;
                        for (int i = 1; i < s.Length; i++)
                        {
                            if (s[i] > '9'|| s[i] <'0')
                                if (s[i] != 'x' && s[i] != 'X' && s[i] != '+' && s[i] != '-' && s[i] != '^')
                                {
                                    MessageBox.Show("неопознанный символ");
                                    textBox2.Focus();
                                    textBox2.Select(i, 1);
                                    return false;
                                }
                            if (s[i] == '+' && (s[i - 1] == '^' || s[i - 1] == '-' || s[i - 1] == '+'))
                            {
                                MessageBox.Show("знаки в многочлене идут по 1");
                                textBox2.Focus();
                                textBox2.Select(i, -1);
                                return false;
                            }
                            else if (s[i] == '-' && (s[i - 1] == '^' || s[i - 1] == '-' || s[i - 1] == '+'))
                            {
                                MessageBox.Show("знаки в многочлене идут по 1");
                                textBox2.Focus();
                                textBox2.Select(i, -1);
                                return false;
                            }
                            else if (s[i] == '^' && (s[i - 1] == '^' || s[i - 1] == '-' || s[i - 1] == '+'))
                            {
                                MessageBox.Show("знаки в многочлене идут по 1");
                                textBox2.Focus();
                                textBox2.Select(i, -1);
                                return false;
                            }
                            else if ((s[i] == 'X' || s[i] == 'x') && (s[i - 1] == 'x' || s[i - 1] == 'X' || s[i - 1] == '^'))
                            {
                                MessageBox.Show("перед x идет коэффициент или знаки '-', '+'");
                                textBox2.Focus();
                                textBox2.Select(i, -1);
                                return false;
                            }
                            else if ((s[i] <= '9' && s[i] >= '0') && (s[i - 1] == 'x' || s[i - 1] == 'X'))
                            {
                                MessageBox.Show("перед цифрой не может идти x");
                                textBox2.Focus();
                                textBox2.Select(i, -1);
                                return false;
                            }
                            else if ((s[i-1] <= '9' && s[i-1] >= '0') && (s[i] == '^'))
                            {
                                MessageBox.Show("степени могут быть только у x");
                                textBox2.Focus();
                                textBox2.Select(i, 1);
                                return false;
                            }
                            if (k == 1 && (s[i] == 'x' || s[i] == 'X'))
                            {
                                MessageBox.Show("x идут по 1");
                                textBox2.Focus();
                                textBox2.Select(i, 1);
                                return false;
                            }
                            else if (s[i] == 'x' || s[i] == 'X') k = 1;
                            else if (k == 1 && (s[i] == '+' || s[i] == '-')) k = 0;
                        }
                    }
                    else
                    {
                        MessageBox.Show("многочлен начинается с x или его коэффициента");
                        textBox2.Focus();
                        textBox2.Select(0, 1);
                        return false;
                    }
                    return true;
                    //break;
                case 1:
                    if (s[0] == 'x' || s[0] == 'X' || s[0] == '-' || char.IsDigit(s[0]) || s[0] == 'a')
                    {
                        int k = 0, h = 0, y = 0;
                        //проверка на x^2a вместо ax^2
                        //ошибка при ax^2 вводе просто
                        if (s[0] == 'x' || s[0] == 'X') { h = 1; y = 1; }
                        if (s[0] == 'a') k = 1;
                        for (int i = 1; i < s.Length; i++)
                        {
                            if (s[i] > '9' || s[i] < '0')
                                if (s[i] != 'x' && s[i] != 'X' && s[i] != '+' && s[i] != '-' && s[i] != '^' && s[i] != 'a')
                                {
                                    MessageBox.Show("неопознанный символ");
                                    textBox2.Focus();
                                    textBox2.Select(i, 1);
                                    return false;
                                }
                            if (s[i] == '+' && (s[i - 1] == '^' || s[i - 1] == '-' || s[i - 1] == '+'))
                            {
                                MessageBox.Show("знаки в многочлене идут по 1");
                                textBox2.Focus();
                                textBox2.Select(i, -1);
                                return false;
                            }
                            else if (s[i] == '-' && (s[i - 1] == '^' || s[i - 1] == '-' || s[i - 1] == '+'))
                            {
                                MessageBox.Show("знаки в многочлене идут по 1");
                                textBox2.Focus();
                                textBox2.Select(i, -1);
                                return false;
                            }
                            else if (s[i] == '^' && (s[i - 1] == '^' || s[i - 1] == '-' || s[i - 1] == '+'))
                            {
                                MessageBox.Show("знаки в многочлене идут по 1");
                                textBox2.Focus();
                                textBox2.Select(i, -1);
                                return false;
                            }
                            else if (s[i] == '^' && (s[i - 1] < '9' && s[i - 1] > '0'))
                            {
                                MessageBox.Show("степень может быть только у x или a");
                                textBox2.Focus();
                                textBox2.Select(i, 1);
                                return false;
                            }
                            else if ((s[i] == 'X' || s[i] == 'x') && (s[i - 1] == 'x' || s[i - 1] == 'X' || s[i - 1] == '^'))
                            {
                                MessageBox.Show("перед x идет коэффициент или знаки '-', '+'");
                                textBox2.Focus();
                                textBox2.Select(i, -1);
                                return false;
                            }
                            else if ((s[i] <= '9' && s[i] >= '0') && ((s[i - 1] == 'x' || s[i - 1] == 'X') || s[i-1] == 'a'))
                            {
                                MessageBox.Show("перед цифрой не может идти x");
                                textBox2.Focus();
                                textBox2.Select(i, -1);
                                return false;
                            }
                            else if ((s[i] == 'a') && (s[i - 1] == 'x' || s[i - 1] == 'X' || s[i - 1] == '^' || s[i - 1] == 'a'))
                            {
                                MessageBox.Show("перед коэффициентом a идет числовой коэффициент или знаки '-', '+'");
                                textBox2.Focus();
                                textBox2.Select(i, -1);
                                return false;
                            }else if(k == 1 && s[i] == 'a')
                            {
                                MessageBox.Show("перед коэффициентом a не может быть еще 1 коэффициента a");
                                textBox2.Focus();
                                textBox2.Select(i, 1);
                                return false;
                            }
                            else if (k == 0 && s[i] == 'a')
                            {
                                k = 1;
                            }
                            else if (k == 1 && (s[i] == 'x' || s[i] == 'X'))
                            {
                                k = 0;
                            }
                            else if ((s[i - 1] <= '9' && s[i - 1] >= '0') && (s[i] == '^'))
                            {
                                MessageBox.Show("степени могут быть только у x и a");
                                textBox2.Focus();
                                textBox2.Select(i, 1);
                                return false;
                            }
                            if (h == 1 && (s[i] == 'x' || s[i] == 'X'))
                            {
                                MessageBox.Show("x идут по 1");
                                textBox2.Focus();
                                textBox2.Select(i, 1);
                                return false;
                            }
                            else if (s[i] == 'x' || s[i] == 'X') h = 1;
                            else if (h == 1 && (s[i] == '+' || s[i] == '-')) h = 0;
                            if(y==1 && s[i] == 'a')
                            {
                                MessageBox.Show("коэффициент должен идти до x");
                                textBox2.Focus();
                                textBox2.Select(i, 1);
                                return false;
                            }
                            else if (s[i] == 'x' || s[i] == 'X') y = 1;
                            else if (y == 1 && (s[i] == '+' || s[i] == '-')) y = 0;
                        }
                    }
                    else
                    {
                        MessageBox.Show("многочлен начинается с x или его коэффициента");
                        textBox2.Focus();
                        textBox2.Select(0, 1);
                        return false;
                    }


                    return true;
                    //break;
            }
            return true;
        }
        public bool isPolinomRightTB3(string s)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    if (s[0] == 'x' || s[0] == 'X' || s[0] == '-' || char.IsDigit(s[0]))
                    {
                        int k = 0;
                        if (s[0] == 'x' || s[0] == 'X') k = 1;
                        for (int i = 1; i < s.Length; i++)
                        {
                            if (s[i] > '9' || s[i] < '0')
                                if (s[i] != 'x' && s[i] != 'X' && s[i] != '+' && s[i] != '-' && s[i] != '^')
                                {
                                    MessageBox.Show("неопознанный символ");
                                    textBox2.Focus();
                                    textBox2.Select(i, 1);
                                    return false;
                                }
                            if (s[i] == '+' && (s[i - 1] == '^' || s[i - 1] == '-' || s[i - 1] == '+'))
                            {
                                MessageBox.Show("знаки в многочлене идут по 1");
                                textBox3.Focus();
                                textBox3.Select(i, -1);
                                return false;
                            }
                            else if (s[i] == '-' && (s[i - 1] == '^' || s[i - 1] == '-' || s[i - 1] == '+'))
                            {
                                MessageBox.Show("знаки в многочлене идут по 1");
                                textBox3.Focus();
                                textBox3.Select(i, -1);
                                return false;
                            }
                            else if (s[i] == '^' && (s[i - 1] == '^' || s[i - 1] == '-' || s[i - 1] == '+'))
                            {
                                MessageBox.Show("знаки в многочлене идут по 1");
                                textBox3.Focus();
                                textBox3.Select(i, -1);
                                return false;
                            }
                            else if ((s[i] == 'X' || s[i] == 'x') && (s[i - 1] == 'x' || s[i - 1] == 'X' || s[i - 1] == '^'))
                            {
                                MessageBox.Show("перед x идет коэффициент или знаки '-', '+'");
                                textBox3.Focus();
                                textBox3.Select(i, -1);
                                return false;
                            }
                            else if ((s[i] <= '9' && s[i] >= '0') && (s[i - 1] == 'x' || s[i - 1] == 'X'))
                            {
                                MessageBox.Show("перед цифрой не может идти x");
                                textBox3.Focus();
                                textBox3.Select(i, -1);
                                return false;
                            }
                            else if ((s[i - 1] <= '9' && s[i - 1] >= '0') && (s[i] == '^'))
                            {
                                MessageBox.Show("степени могут быть только у x");
                                textBox3.Focus();
                                textBox3.Select(i, 1);
                                return false;
                            }
                            if (k == 1 && (s[i] == 'x' || s[i] == 'X'))
                            {
                                MessageBox.Show("x идут по 1");
                                textBox3.Focus();
                                textBox3.Select(i, 1);
                                return false;
                            }
                            else if (s[i] == 'x' || s[i] == 'X') k = 1;
                            else if (k == 1 && (s[i] == '+' || s[i] == '-')) k = 0;
                        }
                    }
                    else
                    {
                        MessageBox.Show("многочлен начинается с x или его коэффициента");
                        textBox3.Focus();
                        textBox3.Select(0, 1);
                        return false;
                    }
                    return true;
                //break;
                case 1:
                    if (s[0] == 'x' || s[0] == 'X' || s[0] == '-' || char.IsDigit(s[0]) || s[0] == 'a')
                    {
                        int k = 0, h = 0, y = 0;
                        if (s[0] == 'x' || s[0] == 'X') { h = 1; y = 1; }
                        if (s[0] == 'a') k = 1;
                        for (int i = 1; i < s.Length; i++)
                        {
                            if (s[i] > '9' || s[i] < '0')
                                if (s[i] != 'x' && s[i] != 'X' && s[i] != '+' && s[i] != '-' && s[i] != '^' && s[i] != 'a')
                                {
                                    MessageBox.Show("неопознанный символ");
                                    textBox2.Focus();
                                    textBox2.Select(i, 1);
                                    return false;
                                }
                            if (s[i] == '+' && (s[i - 1] == '^' || s[i - 1] == '-' || s[i - 1] == '+'))
                            {
                                MessageBox.Show("знаки в многочлене идут по 1");
                                textBox3.Focus();
                                textBox3.Select(i, -1);
                                return false;
                            }
                            else if (s[i] == '-' && (s[i - 1] == '^' || s[i - 1] == '-' || s[i - 1] == '+'))
                            {
                                MessageBox.Show("знаки в многочлене идут по 1");
                                textBox3.Focus();
                                textBox3.Select(i, -1);
                                return false;
                            }
                            else if (s[i] == '^' && (s[i - 1] == '^' || s[i - 1] == '-' || s[i - 1] == '+'))
                            {
                                MessageBox.Show("знаки в многочлене идут по 1");
                                textBox3.Focus();
                                textBox3.Select(i, -1);
                                return false;
                            }
                            else if (s[i] == '^' && (s[i - 1] < '9' && s[i - 1] > '0'))
                            {
                                MessageBox.Show("степень может быть только у x или a");
                                textBox3.Focus();
                                textBox3.Select(i, 1);
                                return false;
                            }
                            else if ((s[i] == 'X' || s[i] == 'x') && (s[i - 1] == 'x' || s[i - 1] == 'X' || s[i - 1] == '^'))
                            {
                                MessageBox.Show("перед x идет коэффициент или знаки '-', '+'");
                                textBox3.Focus();
                                textBox3.Select(i, -1);
                                return false;
                            }
                            else if ((s[i] <= '9' && s[i] >= '0') && ((s[i - 1] == 'x' || s[i - 1] == 'X') || s[i - 1] == 'a'))
                            {
                                MessageBox.Show("перед цифрой не может идти x");
                                textBox3.Focus();
                                textBox3.Select(i, -1);
                                return false;
                            }
                            else if ((s[i] == 'a') && (s[i - 1] == 'x' || s[i - 1] == 'X' || s[i - 1] == '^' || s[i - 1] == 'a'))
                            {
                                MessageBox.Show("перед коэффициентом a идет числовой коэффициент или знаки '-', '+'");
                                textBox3.Focus();
                                textBox3.Select(i, -1);
                                return false;
                            }
                            else if (k == 1 && s[i] == 'a')
                            {
                                MessageBox.Show("перед коэффициентом a не может быть еще 1 коэффициента a");
                                textBox3.Focus();
                                textBox3.Select(i, 1);
                                return false;
                            }
                            else if (k == 0 && s[i] == 'a')
                            {
                                k = 1;
                            }
                            else if (k == 1 && (s[i] == 'x' || s[i] == 'X')){
                                k = 0;
                            }
                            else if ((s[i - 1] <= '9' && s[i - 1] >= '0') && (s[i] == '^'))
                            {
                                MessageBox.Show("степени могут быть только у x и a");
                                textBox3.Focus();
                                textBox3.Select(i, 1);
                                return false;
                            }
                            if (h == 1 && (s[i] == 'x' || s[i] == 'X'))
                            {
                                MessageBox.Show("x идут по 1");
                                textBox3.Focus();
                                textBox3.Select(i, 1);
                                return false;
                            }
                            else if (s[i] == 'x' || s[i] == 'X') h = 1;
                            else if (h == 1 && (s[i] == '+' || s[i] == '-')) h = 0;
                            if (y == 1 && s[i] == 'a')
                            {
                                MessageBox.Show("коэффициент должен идти до x");
                                textBox3.Focus();
                                textBox3.Select(i, 1);
                                return false;
                            }
                            else if (s[i] == 'x' || s[i] == 'X') y = 1;
                            else if (y == 1 && (s[i] == '+' || s[i] == '-')) y = 0;
                        }
                    }
                    else
                    {
                        MessageBox.Show("многочлен начинается с x или его коэффициента");
                        textBox3.Focus();
                        textBox3.Select(0, 1);
                        return false;
                    }


                    return true;
                    //break;
            }
            return true;
        }
        public bool isPolinomRightTB4(string s)
        {
            if (s[0] == 'x' || s[0] == 'X' || s[0] == '-' || char.IsDigit(s[0]))
            {
                int k = 0;
                if (s[0] == 'x' || s[0] == 'X') k = 1;
                for (int i = 1; i < s.Length; i++)
                {
                    if (s[i] > '9' || s[i] < '0')
                        if (s[i] != 'x' && s[i] != 'X' && s[i] != '+' && s[i] != '-' && s[i] != '^')
                        {
                            MessageBox.Show("неопознанный символ");
                            textBox2.Focus();
                            textBox2.Select(i, 1);
                            return false;
                        }
                    if (s[i] == '+' && (s[i - 1] == '^' || s[i - 1] == '-' || s[i - 1] == '+'))
                    {
                        MessageBox.Show("знаки в многочлене идут по 1");
                        textBox5.Focus();
                        textBox5.Select(i, -1);
                        return false;
                    }
                    else if (s[i] == '-' && (s[i - 1] == '^' || s[i - 1] == '-' || s[i - 1] == '+'))
                    {
                        MessageBox.Show("знаки в многочлене идут по 1");
                        textBox5.Focus();
                        textBox5.Select(i, -1);
                        return false;
                    }
                    else if (s[i] == '^' && (s[i - 1] == '^' || s[i - 1] == '-' || s[i - 1] == '+'))
                    {
                        MessageBox.Show("знаки в многочлене идут по 1");
                        textBox5.Focus();
                        textBox5.Select(i, -1);
                        return false;
                    }
                    else if ((s[i] == 'X' || s[i] == 'x') && (s[i - 1] == 'x' || s[i - 1] == 'X' || s[i - 1] == '^'))
                    {
                        MessageBox.Show("перед x идет коэффициент или знаки '-', '+'");
                        textBox5.Focus();
                        textBox5.Select(i, -1);
                        return false;
                    }
                    else if ((s[i] < '9' && s[i] > '0') && (s[i - 1] == 'x' || s[i - 1] == 'X'))
                    {
                        MessageBox.Show("перед цифрой не может идти x");
                        textBox5.Focus();
                        textBox5.Select(i, -1);
                        return false;
                    }
                    else if ((s[i - 1] <= '9' && s[i - 1] >= '0') && (s[i] == '^'))
                    {
                        MessageBox.Show("степени могут быть только у x");
                        textBox5.Focus();
                        textBox5.Select(i, 1);
                        return false;
                    }
                    if (k == 1 && (s[i] == 'x' || s[i] == 'X'))
                    {
                        MessageBox.Show("x идут по 1");
                        textBox5.Focus();
                        textBox5.Select(i, 1);
                        return false;
                    }
                    else if (s[i] == 'x' || s[i] == 'X') k = 1;
                    else if (k == 1 && (s[i] == '+' || s[i] == '-')) k = 0;
                }
            }
            else
            {
                MessageBox.Show("многочлен начинается с x или его коэффициента");
                textBox5.Focus();
                textBox5.Select(0, 1);
                return false;
            }
            return true;
        }
        //работает переводим в нормальный вид и ок
        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.Text == "показать элементы поля")
            {
                dataGridView1.Rows.Clear();
                if(isPolinomRightTB4(textBox5.Text))
                if (numericUpDown1.Text != string.Empty) { 
                    if (isSimple(Convert.ToInt32(numericUpDown1.Text)))
                    {
                        if(Convert.ToInt32(numericUpDown2.Text) < 2)
                            {
                                MessageBox.Show("степень должна быть больше 2");
                                numericUpDown2.Focus();
                                numericUpDown2.Select(0, numericUpDown2.Text.Length);
                                return;
                            }
                            int[]GenPolinom = GetPolinom(textBox5.Text);
                            if (GenPolinom.Length != Convert.ToInt32(numericUpDown2.Text) + 1)
                            {
                                MessageBox.Show("степень порождающего многочлена должна быть равна степени основания поля");
                                textBox5.Focus();
                                textBox5.Select(0, textBox5.Text.Length);
                                return;
                            }
                            GalyaFieldPolinom GF = new GalyaFieldPolinom(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value), GenPolinom);
                        int[][] a = GF.getField();
                            //bool empty = false;
                            for (int i = 0; i < a.Length; i++)
                            {
                                if (a[i] == null)
                                {
                                    MessageBox.Show("по данному многочлену не построить поле с примитивным элементом a");
                                    textBox5.Focus();
                                    textBox5.Select(0, textBox5.Text.Length);
                                    return;
                                }
                            }
                            this.Width = 1268;
                        this.Height = 497;
                        button7.Text = "скрыть элементы поля";
                            checkBox1.Visible= true;
                        //dataGridView1.Rows[0].Cells[0].Value = "векторная форма";
                        if (dataGridView1.ColumnCount == 0)
                        {
                            dataGridView1.Columns.Add("Column1", "степенной вид");
                            dataGridView1.Columns.Add("Column2", "векторная форма");
                        }
                        for (int i = 0; i < a.Length; i++)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells[0].Value = "a^" + i.ToString();
                            for (int j = 0; j < a[i].Length; j++)
                            {
                                if (a[i][j] != 0)
                                {
                                    dataGridView1.Rows[i].Cells[1].Value += a[i][j] + "a^" + (a[i].Length - 1 - j).ToString() + " + ";
                                }
                            }

                            dataGridView1.Rows[i].Cells[1].Value = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value).TrimEnd(' ');
                            dataGridView1.Rows[i].Cells[1].Value = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value).TrimEnd('+');
                        }
                        dataGridView1.RowHeadersVisible = false;
                    }
                    else
                    {
                        MessageBox.Show("основание должно быть простым числом большим 1");
                        numericUpDown1.Focus();
                        numericUpDown1.Select(0, numericUpDown1.Text.Length);
                    }
                }
                else
                {
                    MessageBox.Show("заполните основание поля");
                    numericUpDown1.Focus();
                    numericUpDown1.Select(0, numericUpDown1.Text.Length);
                }
            }
            else
            {
                button7.Text = "показать элементы поля";
                checkBox1.Visible = false;
                this.Width = 814;
                this.Height = 497;
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            string filename = openFileDialog1.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            richTextBox1.Text = fileText;
            MessageBox.Show("Файл открыт");
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            string filename = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(filename, richTextBox1.Text);
            MessageBox.Show("Файл сохранен");
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument documentToPrint = new PrintDocument();
            printDialog1.Document = documentToPrint;

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                StringReader reader = new StringReader(richTextBox1.Text);
                documentToPrint.PrintPage += new PrintPageEventHandler(DocumentToPrint_PrintPage);
                documentToPrint.Print();
            }
        }
        private void DocumentToPrint_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringReader reader = new StringReader(richTextBox1.Text);
            float LinesPerPage = 0;
            float YPosition = 0;
            int Count = 0;
            float LeftMargin = e.MarginBounds.Left;
            float TopMargin = e.MarginBounds.Top;
            string Line = null;
            Font PrintFont = this.richTextBox1.Font;
            SolidBrush PrintBrush = new SolidBrush(Color.Black);

            LinesPerPage = e.MarginBounds.Height / PrintFont.GetHeight(e.Graphics);

            while (Count < LinesPerPage && ((Line = reader.ReadLine()) != null))
            {
                YPosition = TopMargin + (Count * PrintFont.GetHeight(e.Graphics));
                e.Graphics.DrawString(Line, PrintFont, PrintBrush, LeftMargin, YPosition, new StringFormat());
                Count++;
            }

            if (Line != null)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
            PrintBrush.Dispose();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                
                //Task.Run(() => { connectAndAddInDB(); });
            }
            catch
            {
                MessageBox.Show("не получается подключиться к БД");
                checkBox1.Checked = false;
                checkBox1.Visible = false;
            }

            MessageBox.Show("не получается подключиться к БД");
            checkBox1.Checked = false;
            checkBox1.Visible = false;
        }

        //async Task connectAndAddInDB()
        //{
        //    using (ApplicationContext db = new ApplicationContext())
        //    {
        //        string str1 = textBox5.Text;
        //        string f = "";
        //        string prov = "xX+-^";
        //        int d = 0;
        //        for (int i = 0; i < str1.Length; i++)
        //        {
        //            if (str1[i] == '^') d = 1;
        //            if (str1[i] == 'X' || str1[i] == 'x')
        //            {
        //                for (int j = 0; j < prov.Length; j++)
        //                {
        //                    if (i == 0)
        //                    {
        //                        str1 = str1.Insert(i, "1");
        //                        i++;
        //                        break;
        //                    }
        //                    else if (str1[i - 1] == prov[j])
        //                    {
        //                        str1 = str1.Insert(i, "1");
        //                        i++;
        //                        break;
        //                    }
        //                }
        //            }
        //            if (str1[i] == 'X' || str1[i] == 'x')
        //            {
        //                if (i + 1 == str1.Length)
        //                {
        //                    str1 += "^1";
        //                    break;
        //                }
        //                else if (str1[i + 1] != '^')
        //                {
        //                    str1 = str1.Insert(i + 1, "^1");
        //                    d = 1;
        //                    i += 2;
        //                }
        //            }
        //            if (str1[i] < '9' && str1[i] > '0' && d == 0)
        //            {
        //                if (i + 1 < str1.Length)
        //                {
        //                    if (str1[i + 1] == 'x' || str1[i + 1] == 'X') goto exit;
        //                    else while (str1[i] < '9' && str1[i] > '0' && i + 1 < str1.Length)
        //                        {
        //                            if (str1[i + 1] == 'x' || str1[i + 1] == 'X') goto exit;
        //                            i++;
        //                        }
        //                }
        //                str1 = str1.Insert(i + 1, "x^0");
        //                i += 3;
        //            }
        //        exit:;
        //            if (str1[i] == '+' || str1[i] == '-') d = 0;
        //        }
        //        if (button7.Text == "скрыть элементы поля")
        //        {
        //            int[] GenPolinom = GetPolinom(textBox5.Text);
                    
        //            GalyaFieldPolinom GF = new GalyaFieldPolinom(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value), GenPolinom);
        //            int[][] a = GF.getField();
        //            for (int i = 0; i < a.Length; i++)
        //            {
        //                f += $"a^{i};";
        //                for (int j = 0; j < a[i].Length; j++)
        //                {
        //                    f+= $"a^{a[i][j]}+" ;
        //                }
        //                f=f.TrimEnd('+');
        //                f += ";";
        //            }
        //        }

                
        //        Fields pol = new Fields { Q = Convert.ToInt32(numericUpDown1.Text), N = Convert.ToInt32(numericUpDown2.Text), GenerationPolinom = str1, FieldUnit = f };
                
        //        if (db.Field.FirstOrDefault(pol) != null)
        //        {
        //            MessageBox.Show("данные уже были в БД");
        //        }
        //        else
        //        {
        //            db.Field.Add(pol);
        //            db.SaveChanges();
        //            MessageBox.Show("поле успешно сохранено");
        //        }
        //    }
        //}

        

        private void button8_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            string filename = openFileDialog1.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            string[] separator = { Environment.NewLine };
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    string []arr = fileText.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    if (arr.Length != 3)
                    {
                        MessageBox.Show("данные в файле некорректны");
                        break;
                    }
                    int n = 0;
                    if (int.TryParse(arr[0], out n))
                    {
                        numericUpDown1.Text = arr[0];
                        textBox2.Text = arr[1];
                        textBox3.Text = arr[2];
                    }
                    else
                    {
                        MessageBox.Show("данные в файле некорректны");
                    }
                    break;
                case 1:
                    string[] arr1 = fileText.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    if(arr1.Length != 5)
                    {
                        MessageBox.Show("данные в файле некорректны");
                        break;
                    }
                    int n1 = 0, n2 = 0;
                    if (int.TryParse(arr1[0], out n1) && int.TryParse(arr1[1], out n2))
                    {
                         numericUpDown1.Text = arr1[0];
                         numericUpDown2.Text = arr1[1];
                         textBox2.Text = arr1[2];
                         textBox3.Text = arr1[3];
                         textBox5.Text = arr1[4];

                    }
                    else
                    {
                         MessageBox.Show("данные в файле некорректны");
                    }
            break;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (numericUpDown3.Text != string.Empty)
            {
                if (numericUpDown1.Text != string.Empty)
                    if (isSimple(Convert.ToInt32(numericUpDown1.Text)))
                    {
                        if (textBox2.Text == string.Empty)
                        {
                            MessageBox.Show("введите полином 1");
                            textBox2.Focus();
                            textBox2.SelectAll();
                            return;
                        }
                        switch (comboBox1.SelectedIndex)
                        {
                            case 0:
                                if (isPolinomRightTB2(textBox2.Text))
                                {
                                    int[] Polinom = GetPolinom(textBox2.Text);
                                        GalyaField GF = new GalyaField(Convert.ToInt32(numericUpDown1.Text), Polinom);
                                        richTextBox1.Text += $"GF({Convert.ToInt32(numericUpDown1.Text)})\r";

                                    richTextBox1.Text += $"f(x) = {textBox2.Text}";
                                    richTextBox1.Text += $"\rf({numericUpDown3.Text}) = " + GF.findInDot(Convert.ToInt32(numericUpDown3.Text));
                                    richTextBox1.Text += "\r";
                                        richTextBox1.Select(richTextBox1.Text.Length, 0);
                                        richTextBox1.ScrollToCaret();
                                        break;
                                    
                                }
                                else
                                {
                                    return;
                                }
                            case 1:
                                if (textBox5.Text == string.Empty)
                                {
                                    MessageBox.Show("введите порождающий полином");
                                    textBox5.Focus();
                                    textBox5.SelectAll();
                                    return;
                                }
                                if (Convert.ToInt32(numericUpDown2.Text) < 2)
                                {
                                    MessageBox.Show("степень должна быть не меньше 2");
                                    numericUpDown2.Focus();
                                    numericUpDown2.Select(0, numericUpDown2.Text.Length);
                                    break;
                                }
                                if (!isPolinomRightTB4(textBox5.Text)) return;
                                if (!isPolinomRightTB2(textBox2.Text)) return;
                                int[] GenPolinom = GetPolinom(textBox5.Text);
                                if (GenPolinom.Length != Convert.ToInt32(numericUpDown2.Text) + 1)
                                {
                                    MessageBox.Show("степень порождающего многочлена должна быть равна степени основания поля");
                                    textBox5.Focus();
                                    textBox5.Select(0, textBox5.Text.Length);
                                    return;
                                }
                                if(numericUpDown3.Text == string.Empty)
                                {
                                    MessageBox.Show("введите степень a");
                                    numericUpDown1.Focus();
                                    numericUpDown1.Select(0, numericUpDown1.Text.Length);
                                    return;
                                }
                                int[][] Polinom11 = (int[][])getAPolinom(textBox2.Text).Clone();
                                GalyaFieldPolinom GFprobe = new GalyaFieldPolinom(Convert.ToInt32(numericUpDown1.Text), Convert.ToInt32(numericUpDown2.Text), GenPolinom);

                                int[][] a1 = GFprobe.getField();
                                for (int i = 0; i < a1.Length; i++)
                                {
                                    if (a1[i] == null)
                                    {
                                        MessageBox.Show("по данному многочлену не построить поле с примитивным элементом a");
                                        textBox5.Focus();
                                        textBox5.Select(0, textBox5.Text.Length);
                                        return;
                                    }
                                }
                                richTextBox1.Text += $"GF({Convert.ToInt32(numericUpDown1.Text)}^{Convert.ToInt32(numericUpDown2.Text)})\r";
                                int[][] Pol = new int[Polinom11.Length][];
                                for (int i = 0; i < Polinom11.Length; i++)
                                {
                                    Pol[i] = (int[])GFprobe.getFieldUnit(Polinom11[i][1], Polinom11[i][0]).Clone();
                                }
                                GalyaFieldPolinom GFx = new GalyaFieldPolinom(Convert.ToInt32(numericUpDown1.Text), Convert.ToInt32(numericUpDown2.Text), GenPolinom, Pol);
                                richTextBox1.Text += $"f(x) = {textBox2.Text}";
                                richTextBox1.Text += $"\rf({numericUpDown3.Text}) = ";
                                int[]com = GFx.findInDot(GFx.getFieldUnit(Convert.ToInt32(numericUpDown3.Text), Convert.ToInt32(numericUpDown4.Text)));
                                int s = 0;
                                for (int i = 0; i < com.Length; i++)
                                {
                                    if (com[i] != 0) richTextBox1.Text += $"{com[i]}a^{com.Length - 1 - i} + ";
                                    else s++;
                                }
                                if (s == com.Length) richTextBox1.Text += "0";
                                richTextBox1.Text = richTextBox1.Text.TrimEnd(' ');
                                richTextBox1.Text = richTextBox1.Text.TrimEnd('+');
                                richTextBox1.Text += "\r";
                                richTextBox1.Select(richTextBox1.Text.Length, 0);
                                richTextBox1.ScrollToCaret();
                                break;
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("основание должно быть простым числом большим 1");
                        numericUpDown1.Focus();
                        numericUpDown1.Select(0, numericUpDown1.Text.Length);
                    }
            }
            else
            {
                MessageBox.Show("введите точку для нахождения значения");
                numericUpDown3.Focus();
                numericUpDown3.Select(0, numericUpDown1.Text.Length);
            }
        }
    }
    //public class Fields
    //{
    //    public int Id { get; set; }
    //    public int Q { get; set; }
    //    public int N { get; set; }
    //    public string GenerationPolinom { get; set; }
    //    public string FieldUnit { get; set; }
    //}

    //public class ApplicationContext : DbContext
    //{
    //    public Fields Fields { get; set; }
    //    public DbSet<Fields> Field { get; set; }
    //    public ApplicationContext() => Database.EnsureCreated();

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-P7RB159;Initial Catalog=GalyaFieldsUnits;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
    //    }
    //}
}


//проверить все входы ^