using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class frmCalculadora : Form
    {
        string visor = "0"; // Recebe o número informado
        char operacaoAtual; // Recebe a operação que o usuário informar

        bool operacaoUso = false; // Recebe true se uma operação for executada
        bool operacaoUso1 = false;
        bool operacaoUso2 = false;
        bool pontoUso = false;
        bool igualClique = false;
        bool erro = false; // Recebe true se tentar uma divisão por zero

        double num1 = 0;
        double num2 = 0;
        double result = 0;
        double memoResult = 0;
        double memoResult1 = 0;

        // Chamada do form.
        public frmCalculadora()
        {
            InitializeComponent();
        }

        // Limpa a tela caso haja um operador.
        public void TestaOperacaoLimpaVisor()
        {
            igualClique = false;

            if (operacaoUso == true || visor.Equals("0"))
            {
                operacaoUso = false; // Recebe false quando um valor numérico for clicado  
                operacaoUso2 = false;
                visor = "";
                lblVisor.Text = "";
            }
        }

        // Atribui valores aos botões.
        public void pressBotaoNumero(char numero_botao)
        {
            TestaOperacaoLimpaVisor();
            visor = lblVisor.Text;
            visor = visor + numero_botao;
            lblVisor.Text = Convert.ToString(visor);
        }

        // Habilita o uso do Num Lock
        private void keypressNumeros(object sender, KeyPressEventArgs e)
        {
            int botao;

            botao = e.KeyChar;
            switch (botao)
            {
                case 42:
                    pressBotaoFuncao('*');
                    break;
                case 43:
                    pressBotaoFuncao('+');
                    break;
                case 45:
                    pressBotaoFuncao('-');
                    break;
                case 46:
                    pressBotaoFuncao('/');
                    break;
                case 48:
                    pressBotaoNumero('0');
                    break;
                case 49:
                    pressBotaoNumero('1');
                    break;
                case 50:
                    pressBotaoNumero('2');
                    break;
                case 51:
                    pressBotaoNumero('3');
                    break;
                case 52:
                    pressBotaoNumero('4');
                    break;
                case 53:
                    pressBotaoNumero('5');
                    break;
                case 54:
                    pressBotaoNumero('6');
                    break;
                case 55:
                    pressBotaoNumero('7');
                    break;
                case 56:
                    pressBotaoNumero('8');
                    break;
                case 57:
                    pressBotaoNumero('9');
                    break;
            }
        }
        private void btn0_Click(object sender, EventArgs e)
        {
            pressBotaoNumero('0');
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            pressBotaoNumero('1');
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            pressBotaoNumero('2');
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            pressBotaoNumero('3');
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            pressBotaoNumero('4');
        }
        private void btn5_Click(object sender, EventArgs e)
        {
            pressBotaoNumero('5');
        }
        private void btn6_Click(object sender, EventArgs e)
        {
            pressBotaoNumero('6');
        }
        private void btn7_Click(object sender, EventArgs e)
        {
            pressBotaoNumero('7');
        }
        private void btn8_Click(object sender, EventArgs e)
        {
            pressBotaoNumero('8');
        }
        private void btn9_Click(object sender, EventArgs e)
        {
            pressBotaoNumero('9');
        }

        // Cria um valor decimal.
        private void btnPonto_Click(object sender, EventArgs e)
        {
            TestaOperacaoLimpaVisor();
            visor = lblVisor.Text;

            if (pontoUso == false)
            {
                if (visor.Equals("0") || visor.Equals(""))
                    visor = "0,";
                else
                    visor = visor + ",";

                pontoUso = true;
                lblVisor.Text = Convert.ToString(visor);
            }
        }

        // Efetua os cálculos.
        public void executaOperacao()
        {
            if (operacaoUso2 == false)
            {
                if (operacaoUso1 == true)
                {
                    num2 = Double.Parse(lblVisor.Text);
                    num1 = funcoes();
                }
                else if (operacaoUso1 == false)
                    num1 = double.Parse(lblVisor.Text);

                operacaoUso2 = true;
            }

            operacaoUso1 = true; // Fará com que a variável num2 receba os valores após a primeira execução
            operacaoUso = true; // Recebe true toda vez que uma operação é chamada
            pontoUso = false;
        }

        // Define o tipo da operação a ser usada.
        public void pressBotaoFuncao(char funcao)
        {
            executaOperacao();
            operacaoAtual = funcao;
        }
        private void btnSoma_Click(object sender, EventArgs e)
        {
            pressBotaoFuncao('+');
        }
        private void btnDivide_Click(object sender, EventArgs e)
        {
            pressBotaoFuncao('/');
        }
        private void btnSubtrai_Click(object sender, EventArgs e)
        {
            pressBotaoFuncao('-');
        }
        private void btnMultiplica_Click(object sender, EventArgs e)
        {
            pressBotaoFuncao('*');
        }
        private void btnPorcent_Click(object sender, EventArgs e)
        {
            pressBotaoFuncao('%');
        }
        private void btnPotencia_Click(object sender, EventArgs e)
        {
            pressBotaoFuncao('^');
        }
        private void btnRaiz_Click(object sender, EventArgs e)
        {
            pressBotaoFuncao('r');
        }
        private void btnXYPotencia_Click(object sender, EventArgs e)
        {
            pressBotaoFuncao('p');
        }
        private void btnFatorial_Click(object sender, EventArgs e)
        {
            pressBotaoFuncao('f');
        }
        private void btnXRaizY_Click(object sender, EventArgs e)
        {
            pressBotaoFuncao('R');
        }

        // Funções disponíveis para cálculo
        private double funcoes()
        {
            erro = false; // Usada caso seja efetuada um adivisão por zero

            switch (operacaoAtual)
            {
                case '+': result = num1 + num2; break; // Soma
                case '/':
                    if (num2 != 0)
                        result = num1 / num2;
                    else erro = true;
                    break; // Divide
                case '-': result = num1 - num2; break; // Subtrai
                case '*': result = num1 * num2; break; // Multiplica
                case '%': result = num2 > 0 ? num1 * num2 / 100 : 0; break; // Efetua a porcentagem
                case '^': result = Math.Pow(num1, 2); break; // Eleva um número a dois
                case 'r': result = Math.Sqrt(num1); break; // raiz quadrada
                case 'p': result = Math.Pow(num1, num2); break; // Eleva um número a outro
                case 'f':
                    result = 1;
                    if (num2 > 0)
                    {
                        for (int i = 1; i <= num2; i++)
                            result = result * i;
                    }
                    break;
                case 'R': result = Math.Pow(num1, 1 / num2); break;
            }

            // Imprime mensagem de erro caso seja efetuada divisão por zero, caso contrário o valor de result.
            lblVisor.Text = erro == true ? "ERROR" : lblVisor.Text = Convert.ToString(result);

            // O retorno será usado se a memória for acionada.
            return result = erro == false ? result : 0;
        }

        // Executa a operação com o botão de igual
        private void btnIgual_Click(object sender, EventArgs e)
        {
            if (operacaoUso1 == true)
            {
                if (igualClique == false)
                {
                    num2 = Double.Parse(lblVisor.Text);
                    igualClique = true;
                }

                num1 = funcoes();
            }
            else if (operacaoUso1 == false)
                num1 = double.Parse(lblVisor.Text);

            operacaoUso = true;
            operacaoUso1 = false;
            pontoUso = false;
        }
        // Limpa as variáveis da calculadora.
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            lblVisor.Text = "0";
            visor = "0";
            operacaoAtual = ' ';

            operacaoUso = false;
            operacaoUso1 = false;
            operacaoUso2 = false;
            igualClique = false;
            pontoUso = false;

            num1 = 0;
            num2 = 0;
            result = 0;
        }
        // Apaga o último número digitado (backsapce).
        private void btnCorrige_Click(object sender, EventArgs e)
        {
            if (operacaoUso == false)
            {
                visor = lblVisor.Text;
                if (visor.Length > 0)
                    visor = visor.Substring(0, visor.Length - 1);

                lblVisor.Text = visor;
            }
        }

        // Funções da memória.
        public void memoria()
        {
            lblMemoria.Text = "M";
            memoResult = double.Parse(lblVisor.Text);
        }
        private void btnMLimpa_Click(object sender, EventArgs e)
        {
            memoResult = 0;
            memoResult1 = 0;
            lblMemoria.Text = null;
        }
        private void btnMMostra_Click(object sender, EventArgs e)
        {
            lblVisor.Text = Convert.ToString(memoResult);
        }
        private void btnMMais_Click(object sender, EventArgs e)
        {
            memoOperacao('+');
        }
        private void btnMMenos_Click(object sender, EventArgs e)
        {
            memoOperacao('-');
        }
        private void memoOperacao(char x)
        {
            memoria();
            lblVisor.Text = Convert.ToString(memoResult);
            memoResult1 = x == '+' ? memoResult1 + memoResult : memoResult1 - memoResult;
            memoResult = memoResult1;
        }

        private void btnDesliga_Click(object sender, EventArgs e)
        {
            lblVisor.TextAlign = ContentAlignment.MiddleLeft;
            lblVisor.Text = "DESLIGANDO";
            Application.DoEvents();
            System.Threading.Thread.Sleep(500);
            lblVisor.Text = "DESLIGANDO.";
            Application.DoEvents();
            System.Threading.Thread.Sleep(500);
            lblVisor.Text = "DESLIGANDO..";
            Application.DoEvents();
            System.Threading.Thread.Sleep(500);
            lblVisor.Text = "DESLIGANDO...";
            Application.DoEvents();
            System.Threading.Thread.Sleep(500);
            lblVisor.Text = "DESLIGANDO....";
            Application.DoEvents();
            System.Threading.Thread.Sleep(500);
            lblVisor.Text = "DESLIGANDO.....";
            Application.DoEvents();
            System.Threading.Thread.Sleep(500);
            lblVisor.TextAlign = ContentAlignment.MiddleCenter;
            lblVisor.Text = "CLUSTERS v 1.0.0";
            Application.DoEvents();
            System.Threading.Thread.Sleep(2000);
            frmCalculadora.ActiveForm.Close();

        }
    }
}
