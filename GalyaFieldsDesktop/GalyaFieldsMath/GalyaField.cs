using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace GalyaFieldsMath
{
    public class GalyaMain
    {
        protected int q;

        public GalyaMain() { }
        public GalyaMain(int q) { this.q = q; }

        public int getQ()
        {
            return q;
        }

        public virtual string print()
        {
            return "GF(" + q.ToString() + ")\n";
        }
    }
    public class GalyaField:GalyaMain
    {
        protected int[] Polinom;

        //public GalyaField(int q1) :base(q1) { }
        public GalyaField(int q1, int []Polinom1) : base(q1)
        {
           // q=q1;
            this.Polinom = Polinom1; 
            
        }

        public int[] getPolinom()
        {
            return this.Polinom;
        }
        //public GalyaField(int q1, int n1, int[]GenerationPolynomial1)
        //{
        //    q = q1; n = n1;
        //    Polinom = new int[Convert.ToInt32(Math.Pow(q, n))];
        //    //Array.Resize(ref GeneratingPolynomial, Convert.ToInt32(Math.Pow(q, n)));

        //    for (int i = 0; i < GenerationPolynomial1.Length; i++)
        //    {
        //        Polinom[i] = GenerationPolynomial1[i];
        //    }
        //}
        public static GalyaField operator +(GalyaField GF1, GalyaField GF2)
        {
            if (GF1.Polinom.Length < GF2.Polinom.Length)
            {
                int[] need = (int[])GF2.Polinom.Clone();
                int j = GF2.Polinom.Length - GF1.Polinom.Length;
                for (int i = 0; i < GF1.Polinom.Length; i++)
                {
                    need[i + j] += GF1.Polinom[i];
                    while (need[i + j] < 0) need[i + j] += GF1.q;
                }
                for (int i = 0; i < GF1.Polinom.Length; i++)
                {
                    need[i] %= GF1.q;
                }
                return new GalyaField(GF1.q, need);
            }
            else
            {
                int[] need1 = (int[])GF1.Polinom.Clone();
                int j = GF1.Polinom.Length - GF2.Polinom.Length;
                for (int i = 0; i < GF2.Polinom.Length; i++)
                {
                    need1[i + j] += GF2.Polinom[i];
                    while (need1[i + j] < 0) need1[i + j] += GF1.q;
                }
                for (int i = 0; i < GF1.Polinom.Length; i++)
                {
                    need1[i] %= GF1.q;
                }
                return new GalyaField(GF1.q, need1);
            }
        }
        public static GalyaField operator -(GalyaField GF1, GalyaField GF2)
        {
            //GalyaField GF = new GalyaField(GF1.q, GF1.Polinom);
            //for (int i = 0; i < GF1.Polinom.Length; i++)
            //{
            //    //GF.Polinom[i] = GF1.Polinom[i] - GF2.Polinom[i];
            //    GF2.Polinom[i] += -GF2.Polinom[i] ;
            //    GF1.Polinom[i] += GF2.Polinom[i];
            //    GF1.Polinom[i] %= GF1.q;
            //    //GF.Polinom[i] %= GF.q;
            //}
            return (GF1 +(-GF2));
        }

        public static GalyaField operator -(GalyaField GF1)
        {
            for (int i = 0; i < GF1.Polinom.Length; i++)
            {
                GF1.Polinom[i] = -GF1.Polinom[i];
            }
            return GF1;
        }

        public static GalyaField operator *(GalyaField GF1, GalyaField GF2)
        {
            int[] Polinom = new int[GF1.Polinom.Length + GF2.Polinom.Length - 1];
            //int[][]matrix = new int[GF1.Polinom.Length][];
            //for (int i = 0; i < GF1.Polinom.Length; i++)
            //{
            //    matrix[i] = new int[Polinom.Length];
            //    int k = 0;
            //    for (int j = 0; j < Polinom.Length; j++)
            //    {
            //        matrix[i][j] = GF1.Polinom[k];
            //        k++;
            //    }
            //}
            for (int i = 0; i < Polinom.Length; i++)
                Polinom[i] = 0;
            for (int i = 0; i < GF1.Polinom.Length; i++)
            {
                for (int j = 0; j < GF2.Polinom.Length; j++)
                {
                    Polinom[i + j] += GF1.Polinom[i] * GF2.Polinom[j];
                    Polinom[i + j] %= GF1.q;
                }
            }
            return new GalyaField(GF1.q, Polinom);
        }
        //работает
        public static GalyaField operator/(GalyaField GF1, GalyaField GF2 /*out double[] quotient, out double[] remainder*/)
        {
            //if (GF1.Polinom.Last() == 0)
            //{
            //    throw new ArithmeticException("Старший член многочлена делимого не может быть 0");
            //}
            //if (GF2.Polinom.Last() == 0)
            //{
            //    throw new ArithmeticException("Старший член многочлена делителя не может быть 0");
            //}
            int[] remainder = (int[])GF1.Polinom.Clone();
            if(GF1.Polinom.Length - GF2.Polinom.Length + 1 < 0)return new GalyaField(GF1.q, new int[0]);
            int []quotient = new int[GF1.Polinom.Length - GF2.Polinom.Length + 1];
            for (int i = 0; i < quotient.Length; i++)
            {
                //int coeff = remainder[remainder.Length - i - 1] * invmod(GF2.Polinom.First(),GF2.q);
                int coeff = remainder[i] * invmod(GF2.Polinom.First(), GF2.q);
                quotient[i] = (coeff + GF1.q) % GF1.q;
                for (int j = 0; j < GF2.Polinom.Length; j++)
                {
                    //remainder[remainder.Length - i - j - 1] -= coeff * GF2.Polinom[j];
                    remainder[i + j] -= coeff * GF2.Polinom[j];
                }
            }
            return new GalyaField(GF1.q, quotient);
        }
        static (int, int, int) gcdex(int a, int b)
        {
            if (a == 0)
                return (b, 0, 1);
            (int gcd, int x, int y) = gcdex(b % a, a);
            return (gcd, y - (b / a) * x, x);
        }

        static int invmod(int a, int m)
        {
            (int g, int x, int y) = gcdex(a, m);
            return g > 1 ? 0 : (x % m + m) % m;
        }
        //работает
        public int[] findRoots()
        {
            int []n = new int[0];
            int sum = 0;
            for (int i = 0; i < q; i++)
            {
                for (int j = 0; j < Polinom.Length - 1; j++)
                {
                    if (Polinom[j] != 0)
                    {
                        int h = i;
                        for (int z = 1; z < Polinom.Length - 1 - j; z++)
                        {
                            h *= i;
                            h %= q;
                        }
                        sum += (Polinom[j] * h/*Convert.ToInt32(Math.Pow(i, Polinom.Length - 1 - j))*/);
                    }
                }
                sum += Polinom.Last();
                sum %= q;
                if(sum == 0)
                {
                    Array.Resize(ref n, n.Length + 1);
                    n[n.Length - 1] = i;
                }
                sum = 0;
            }
            return n;
        }

        public int findInDot(int x)
        {
            int y = Polinom[0];
            for (int i = 0; i < Polinom.Length - 1; i++)
            {
                y *= x;
                y += Polinom[i + 1];
                y %= q;
            }
            return y;
        }

        public string printPolinom()
        {
            string str2 = "";
            if (Polinom != null)
                for (int i = 0; i < Polinom.Length; i++)
                {
                    if (Polinom[i] != 0)
                    {
                        str2 += Polinom[i] + "X" + $"^{Polinom.Length - 1 - i}";
                        if (i + 1 != Polinom.Length) str2 += " + ";
                    }
                }
            str2 = str2.TrimEnd(' ');
            str2 = str2.TrimEnd('+');
            str2 = str2.TrimEnd('0');
            str2 = str2.TrimEnd('^');
            str2 = str2.TrimEnd('X');
            if (str2 == "") str2 += "0";
            return str2;
        }

        public override string print()
        {
            //string str1 = "GF(" + q.ToString() + ")\n";
            string str2 = "";
            if(Polinom != null ) 
            for(int i = 0 ; i < Polinom.Length; i++)
            {
                    if (Polinom[i] != 0)
                    {
                        str2 += Polinom[i] + "X" + $"^{Polinom.Length - 1-i}";
                        if (i + 1 != Polinom.Length) str2 += " + ";
                    }
            }
            str2 = str2.TrimEnd(' ');
            str2 = str2.TrimEnd('+');
            str2 = str2.TrimEnd('0');
            str2 = str2.TrimEnd('^');
            str2 = str2.TrimEnd('X');
            if (str2 == "") str2 += "0";
            str2 += "\n";
            return base.print() + str2;
        }
    }


    /*Тут поля, для которых нужен порождающий многочлен*/

    public class GalyaFieldPolinom : GalyaMain
    {
        int n;
        int[] GenerationPolynomial;
        int[][] ?Field;
        int[][]? Polinom;

        public int getN()
        {
            return n;
        }
        public int[] getGenerationPol() 
        { 
            return GenerationPolynomial; 
        }
        public int[][] getField()
        {
            return Field;
        }
        public void setPolinom(int[][] Pol)
        {
            this.Polinom = (int[][])Pol.Clone();
        }

        //public GalyaFieldPolinom(int q1, int n1, int[][] Polinom1) : base(q1)
        //{
        //    Polinom = Polinom1;
        //}

        public GalyaFieldPolinom(int q1, int n1, int[] GenerationPolinom1) : base(q1)
        {
            this.n = n1;
            this.GenerationPolynomial = GenerationPolinom1;
            GenerateField();
        }

        public GalyaFieldPolinom(int q1, int n1, int[][] Polinom1) : base(q1)
        {
            this.n = n1;
            this.Polinom = Polinom1;
            GeneratePolinom();
            GenerateField();
        }

        public void GeneratePolinom()
        {

        }

        public int[] mulArray(int[] last)
        {
            int[] arr = new int[n];
            int[] downSt= new int[n];
            int k = 1;
            for (int i = downSt.Length-1; i > -1; i--)
            {
                downSt[i] = -GenerationPolynomial[GenerationPolynomial.Length - k];
                while (downSt[i] < 0) downSt[i] += q;
                downSt[i] %= q;
                k++;
            }
            for (int i = 0; i < n - 1; i++)
            {
                arr[i] += last[i + 1];
            }
            if (last[0] != 0)
            {
                for (int i = 0; i < n; i++)
                {
                    arr[i] += downSt[i] * last[0];
                    arr[i] %= q;
                }
            }
            return arr;
        }
        public void GenerateField()
        {
            Field = new int[Convert.ToInt32(Math.Pow(q, n))][];
                Field[0] = new int[n];
            for (int i = 0; i < n-1; i++)
            {
                Field[0][i] = 0;
            }
            Field[0][n-1] = 1;
            for (int i = 1; i < Field.Length; i++)
            {
                Field[i] = new int[n];
                Field[i] = mulArray(Field[i-1]);
                for (int j = 0; j < i; j++)
                {
                    if (i == Convert.ToInt32(Math.Pow(q, n)) - 1) break;
                    int l = 0;
                    for (int z = 0; z < n; z++)
                    {
                        if (Field[i][z] == Field[j][z]) l++;
                    }
                    if(l == n) goto flag;
                }
            }
        flag:;
        }

        public GalyaFieldPolinom(int q1, int n1, int[] GenerationPolynomial1, int[][] Polinom1) : base(q1)
        {
            this.n = n1;
            this.GenerationPolynomial = GenerationPolynomial1;
            this.Polinom = Polinom1;
            GenerateField();
        }

        public int[] getFieldUnit(int l, int k)
        {
            l %= Convert.ToInt32(Math.Pow(q, n)) - 1;
            if (k == 0)
            {
                int[] ints = new int[n];
                for (int i = 0; i < n; i++)
                {
                    ints[i] = 0;
                }
                return ints;
            }
            if(k == 1)
            {
                return Field[l];
            }
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = (Field[l][i] * k) % q;
            }
            return arr;
        }

        public int[][] getPolinom()
        {
            return this.Polinom;
        }

        public static GalyaFieldPolinom operator+(GalyaFieldPolinom GF1, GalyaFieldPolinom GF2)
        {
            if (GF1.Polinom.Length < GF2.Polinom.Length)
            {
                int j = GF2.Polinom.Length - GF1.Polinom.Length;
                for (int i = 0; i < GF1.Polinom.Length; i++)
                {
                    for (int j2 = 0; j2 < GF1.Polinom[i].Length; j2++)
                    {
                        GF2.Polinom[i + j][j2] += GF1.Polinom[i][j2];
                        while (GF2.Polinom[i + j][j2] < 0) GF2.Polinom[i + j][j2] += GF1.q;
                    }
                }
                for (int i = 0; i < GF2.Polinom.Length; i++)
                {
                    for (int j2 = 0; j2 < GF2.Polinom[i].Length; j2++)
                    {
                        GF2.Polinom[i][j2] %= GF1.q;
                    }
                }
                return new GalyaFieldPolinom(GF1.q, GF1.n, GF1.GenerationPolynomial, GF2.Polinom);
            }
            else
            {
                int j = GF1.Polinom.Length - GF2.Polinom.Length;
                for (int i = 0; i < GF2.Polinom.Length; i++)
                {
                    for (int j2 = 0; j2 < GF2.Polinom[i].Length; j2++)
                    {
                        GF1.Polinom[i + j][j2] += GF2.Polinom[i][j2];
                        while (GF1.Polinom[i + j][j2] < 0) GF1.Polinom[i + j][j2] += GF1.q;
                    }
                }
                for (int i = 0; i < GF1.Polinom.Length; i++)
                {
                    for (int j2 = 0; j2 < GF1.Polinom[i].Length; j2++)
                    {
                        GF1.Polinom[i][j2] %= GF1.q;
                    }
                }
                return new GalyaFieldPolinom(GF1.q, GF1.n, GF1.GenerationPolynomial, GF1.Polinom);
            }
            //if (GF1.Polinom.Length <= GF2.Polinom.Length)
            //{
            ////int[][] Pol = new int[Math.Max(GF1.Polinom.Length, GF2.Polinom.Length)][];
            ////int k = 0, h = 0;
            ////for (int i = 0; i < Pol.Length; i++)
            ////{
            ////    Pol[i] = new int[GF1.n];
            ////    for (int j = 0; j < GF1.n; j++)
            ////    {
            ////        Pol[i][j] = 0;
            ////    }
            ////}
            ////    for (int i = 0; i < Pol.Length; i++)
            ////    {
            ////    if(GF1.Polinom.Length - Pol.Length + i > 0)
            ////    {
            ////        for (int j = 0; j < GF1.n; j++)
            ////        {
            ////            Pol[i][j] += GF1.Polinom[k][j];
            ////            Pol[i][j] %= GF1.q;
            ////        }
            ////        //Pol[i] = GF1.sum(Pol[i], GF1.Polinom[k]);
            ////        k++;
            ////    }
            ////    if (GF2.Polinom.Length - Pol.Length + i > 0)
            ////    {
            ////        for (int j = 0; j < GF1.n; j++)
            ////        {
            ////            Pol[i][j] += GF2.Polinom[h][j];
            ////            Pol[i][j] %= GF1.q;
            ////        }
            ////        //Pol[i] = GF1.sum(Pol[i], GF2.Polinom[h]);
            ////        h++;
            ////    }
            ////}
            ////    return new GalyaFieldPolinom(GF1.q,GF1.n, GF1.GenerationPolynomial, Pol);
            //}
            //else
            //{
            //    for (int i = 0; i < GF2.Polinom.Length; i++)
            //    {
            //        for (int j = 0; j < GF1.n; j++)
            //        {
            //            GF1.Polinom[i][j] += GF1.Polinom[i][j];
            //            GF1.Polinom[i][j] %= GF1.q;
            //        }
            //    }
            //    return GF1;
            //}
        }
        public static GalyaFieldPolinom operator -(GalyaFieldPolinom GF1, GalyaFieldPolinom GF2)
        {
            
            return GF1 +(-GF2);
        }
        public static GalyaFieldPolinom operator -(GalyaFieldPolinom GF1)
        {
            for (int i = 0; i < GF1.Polinom.Length; i++)
            {
                for (int j = 0; j < GF1.n; j++)
                {
                    GF1.Polinom[i][j] = -GF1.Polinom[i][j];
                    while (GF1.Polinom[i][j] < 0) GF1.Polinom[i][j] += GF1.q;
                    GF1.Polinom[i][j] %= GF1.q;
                }
            }
            return GF1;
        }

        
        public static GalyaFieldPolinom operator *(GalyaFieldPolinom GF1, GalyaFieldPolinom GF2)
        {
            int[][] Polinom = new int[GF1.Polinom.Length + GF2.Polinom.Length - 1][];
            for (int i = 0; i < Polinom.Length; i++)
                Polinom[i] = new int[GF1.n];
            for (int i = 0; i < GF1.Polinom.Length; i++)
            {
                for (int j = 0; j < GF2.Polinom.Length; j++)
                {
                    if (GF1.getNumber(GF1.Polinom[i]) != -1 && GF1.getNumber(GF2.Polinom[j]) != -1)
                    {
                        int[] c = GF1.Field[(GF1.getNumber(GF1.Polinom[i]) + GF2.getNumber(GF2.Polinom[j])) % (Convert.ToInt32(Math.Pow(GF1.q, GF1.n)) - 1)];
                        Polinom[i + j] = GF1.sum(Polinom[i + j], c);
                    }
                    for (int z = 0; z < Polinom[i + j].Length; z++)
                    {
                        Polinom[i + j][z] %= GF1.q;
                    }
                }
            }
            return new GalyaFieldPolinom(GF1.q, GF1.n, GF1.GenerationPolynomial, Polinom);
        }
        public int[] sum(int[] a, int[] b)
        {
            int[] c = new int[n];
            for (int i = 0; i < n; i++)
            {
                c[i] = (a[i] + b[i]) % q;
            }
            //c = Field[(getNumber(a) + getNumber(b)) % n];
            return c;
        }

        public int getNumber(int[] a)
        {
            for (int i = 0; i < Field.Length; i++)
            {
                int k = 0;
                for (int j = 0; j < n; j++)
                {
                    if (Field[i][j] == a[j])
                    {
                        k++;
                    }
                }
                if (k == n) return i;
            }
            return -1;
        }
        //перевести все в вид (a^7)X^2... чтобы делить одномерные массивы, а не двумерные
        public static GalyaFieldPolinom operator /(GalyaFieldPolinom GF1, GalyaFieldPolinom GF2)
        {
            int [][]firstPol = (int[][])GF1.Polinom.Clone();
            //int[] secondPol = new int[GF2.Polinom.Length];
            //for (int i = 0; i < GF1.Polinom.Length; i++)
            //{
            //    firstPol[i] = GF1.getNumber(GF1.Polinom[i]);
            ////}
            //for (int i = 0; i < GF2.Polinom.Length; i++)
            //{
            //    secondPol[i] = GF2.getNumber(GF2.Polinom[i]);
            //}
            if(GF1.Polinom.Length - GF2.Polinom.Length + 1 < 0)return new GalyaFieldPolinom(GF1.q, GF1.n, GF1.GenerationPolynomial, new int[0][]);
            int[][] findPol = new int[GF1.Polinom.Length - GF2.Polinom.Length + 1][];
            for (int i = 0; i < findPol.Length; i++)
            {
                findPol[i] = new int[GF1.n];
            }
            for (int i = 0; i < findPol.Length; i++)
            {
                //int coeff = remainder[remainder.Length - i - 1] * invmod(GF2.Polinom.First(),GF2.q);
                if(GF2.getNumber(firstPol[i]) == -1) 
                {
                    for (int j = 0; j < findPol[i].Length; j++)
                    {
                        findPol[i][j] = 0;
                    }
                }
                else { 
                int coeff = GF2.getNumber(firstPol[i]) + GF1.invmod(GF2.getNumber(GF2.Polinom.First()), GF1);
                findPol[i] = GF1.Field[coeff % (Convert.ToInt32(Math.Pow(GF1.q, GF1.n)) - 1)];
                for (int j = 0; j < GF2.Polinom.Length; j++)
                {
                        //remainder[remainder.Length - i - j - 1] -= coeff * GF2.Polinom[j];
                        //firstPol[i + j] -= secondPol[coeff];
                        if (GF2.getNumber(firstPol[j]) != -1)
                        {
                            int[] a = (int[])GF2.Field[(GF2.getNumber(GF2.Polinom[j]) + coeff) % (Convert.ToInt32(Math.Pow(GF1.q, GF1.n)) - 1)].Clone();
                            for (int z = 0; z < GF1.n; z++)
                            {
                                firstPol[i + j][z] -= a[z];
                            }
                        }
                }
                }
            }
            return new GalyaFieldPolinom(GF1.q, GF1.n, GF1.GenerationPolynomial, findPol);
        }
        public int invmod(int number, GalyaFieldPolinom GF1)
        {
            for (int i = 0; i < GF1.Field.Length; i++)
            {
                if ((number + i) % Convert.ToInt32(Math.Pow(GF1.q, GF1.n) - 1) == 0) return i;
            }

            return 0;
        }
        //нужно продумать алгоритм получения add
        //переписать под работу с подмассивом a^, после чего переводить его в элемент поля и радоваться
        /*public int[][] findRoots()
        {
            int[][] k = new int[0][];
            int []sum = new int[n];
            for (int i = 0; i < sum.Length; i++)
            {
                sum[i] = 0;
            }
            if (this.getNumber(Polinom[Polinom.Length - 1]) == -1)
            {
                Array.Resize(ref k, k.Length + 1);
                k[0] = new int[n];
                for (int i = 0; i < k[0].Length; i++)
                {
                    k[0][i] = 0;
                }
            }
            for (int i = 0; i < Field.Length - 1; i++)
            {
                for (int j = 0; j < Polinom.Length; j++)
                {
                    if (this.getNumber(Polinom[j]) != -1)
                    {
                        int[] add = (int[])Field[(getNumber(Polinom[j]) + Convert.ToInt32(Math.Pow(i, Polinom.Length - 1 - j))) % (Convert.ToInt32(Math.Pow(q, n)) - 1)].Clone();
                        for (int z = 0; z < n; z++)
                        {
                            sum[z] += add[z];
                            sum[z] %= q;
                        }
                        //sum = this.sum(sum, add);
                    }
                }
                //for (int z = 0; z < n; z++)
                //{
                //    sum[z] %= q;
                //}
                if (getNumber(sum) == -1)
                {
                    Array.Resize(ref k, k.Length + 1);
                    k[k.Length - 1] = (int[])Field[i].Clone();
                }
                for (int j = 0; j < sum.Length; j++)
                {
                    sum[j] = 0;
                }
            }
            return k;
        }*/
        //нужно найти ошибку
        public int[] findRoots()
        {
            int[] k = new int[0];
            int[] sum = new int[n];
            for (int i = 0; i < sum.Length; i++)
            {
                sum[i] = 0;
            }
            if (this.getNumber(Polinom[Polinom.Length - 1]) == -1)
            {
                Array.Resize(ref k, k.Length + 1);
                k[0] = -1;
            }
            for (int j = 0; j < Field.Length - 1; j++) 
            {
                for (int i = 0; i < Polinom.Length - 1; i++)
                {
                    if (this.getNumber(Polinom[i]) != -1)
                    {
                        int h = j;
                        for (int z = 1; z < Polinom.Length - 1 - i; z++)
                        {
                            h *= j;
                            h %= (Field.Length - 1);
                        }
                        sum = this.sum(sum, Field[(this.getNumber(Polinom[i]) + h/*Convert.ToInt32(Math.Pow(j, Polinom.Length - 1 - i))*/) % (Field.Length - 1)]);
                    }
                        //if (j == 2) {
                    //    int l = this.getNumber(Polinom[i]);
                    //    int m = Convert.ToInt32(Math.Pow(j, Polinom.Length - 1 - i));
                    //    int[] rr = Field[(this.getNumber(Polinom[i]) + Convert.ToInt32(Math.Pow(j, Polinom.Length - 1 - i))) % (Field.Length - 1)];
                    //     }
                }
                sum = this.sum(sum, Polinom[Polinom.Length - 1]);
                //if(j==2)
                //throw new Exception();
                if (this.getNumber(sum) == -1)
                {
                    //throw new Exception();
                    Array.Resize(ref k, k.Length + 1);
                    k[k.Length - 1] = j;
                }
                for (int z = 0; z < sum.Length; z++)
                {
                    sum[z] = 0;
                }
            }

            return k;
        }

        public int[] findInDot(int[] x)
        {
            int[] y = (int[])Polinom[0].Clone();
            for (int i = 0; i < Polinom.Length - 1; i++)
            {
                if ((getNumber(y) != -1 && getNumber(x) != -1)){
                    y = getFieldUnit((getNumber(y) + getNumber(x)) % (n * q - 1), 1);
                    for (int j = 0; j < n; j++)
                    {
                        y[j] += Polinom[i + 1][j];
                        y[j] %= q;
                    }
                }
                //y += Polinom[i + 1];
                //y %= q;
            }
            return y;
        }
        public string printPolinom()
        {
            string str2 = "";
            for (int i = 0; i < Polinom.Length; i++)
            {
                str2 += "(";
                for (int j = 0; j < Polinom[i].Length; j++)
                {
                    if (Polinom[i][j] != 0)
                        str2 += Polinom[i][j] + $"a^{q - 1 - j} + ";
                }
                str2 = str2.TrimEnd(' ');
                str2 = str2.TrimEnd('+');
                str2 = str2.TrimEnd(' ');
                if (str2.Last() != '(')
                    str2 += $") * X^{Polinom.Length - 1 - i} + ";
                else str2 = str2.TrimEnd('(');
            }
            str2 = str2.TrimEnd(' ');
            str2 = str2.TrimEnd('+');
            str2 = str2.TrimEnd(' ');
            str2 = str2.TrimEnd('0');
            str2 = str2.TrimEnd('^');
            str2 = str2.TrimEnd('X');
            str2 = str2.TrimEnd(' ');
            str2 = str2.TrimEnd('*');
            if (str2 == "") str2 += "0";
            str2 += "\n";
            return str2;
        }

        public virtual string print()
        {
            string str0 = "GF(" + q.ToString() + '^' + n.ToString() + ")\n";
            string str1 = "";
            for (int i = 0; i < GenerationPolynomial.Length; i++)
            {
                if (GenerationPolynomial[i] != 0)
                {
                    str1 += GenerationPolynomial[i] + "X" + $"^{GenerationPolynomial.Length - 1 - i}";
                    str1 += " + ";
                }
            }
            str1 = str1.TrimEnd(' ');
            str1 = str1.TrimEnd('+');
            str1 += "\n";

            string str2 = "";
            for (int i = 0; i < Polinom.Length; i++)
            {
                str2 += "(";
                for (int j = 0; j < Polinom[i].Length; j++)
                {
                    if(Polinom[i][j] != 0)
                    str2 += Polinom[i][j] + $"a^{q-1-j} + ";
                }
                str2 = str2.TrimEnd(' ');
                str2 = str2.TrimEnd('+');
                str2 = str2.TrimEnd(' ');
                if (str2.Last() != '(')
                    str2 += $") * X^{Polinom.Length - 1 - i} + ";
                else str2 = str2.TrimEnd('(');
            }
            str2 = str2.TrimEnd(' ');
            str2 = str2.TrimEnd('+');
            str2 = str2.TrimEnd('0');
            str2 = str2.TrimEnd('^');
            str2 = str2.TrimEnd('X');
            if (str2 == "") str2 += "0";
            str2 += "\n";

            string str3 = "";
            for (int i = 0; i < Field.Length; i++)
            {
                for (int j = 0; j < Field[i].Length; j++)
                {
                    str3 += Field[i][j] + "  ";
                }
                str3 += "\n";
            }
            return str0 + str1 + str2 + str3;
        }
    }
}