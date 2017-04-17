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
        string visor        = "0"; // Recebe o número informado
        char operacaoAtual; // Recebe a operação que o usuário informar        

        bool operacaoUso    = false; // Recebe tru se uma operação for executada
        bool operacaoUso1   = false;
        bool operacaoUso2   = false;
        bool pontoUso       = false;
        bool igualClique    = false;
        bool erro           = false;

        double num1         = 0;
        double num2         = 0;
        double result       = 0;
        double memoResult   = 0;
        double memoResult1  = 0;
        
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
                //operacaoUso2 = true;
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

        // Cria um valor com ponto.
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

        // Efetua as funções.
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
            //TestaOperacaoLimpaVisor();
            operacaoAtual = funcao;
            executaOperacao();
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

        // Para que não haja replicação de código.
        private double funcoes()
        {
            erro = false;

            switch (operacaoAtual)
            {
                case '+': result = num1 + num2; break; // Soma
                case '/': if (num2 != 0) result = num1 / num2; else erro = true; break; // Divide
                case '-': result = num1 - num2; break; // Subtrai
                case '*': result = num1 * num2; break; // Multiplica
                case '%': result = num2 > 0 ? num1 * num2 / 100 : 0; break; // Efeua a porcentagem
                case '^': result = Math.Pow(num1, 2); break; // Eleva um número a dois
                case 'r': result = Math.Sqrt(num1); break; // raiz quadrada
                case 'p': result = Math.Pow(num1, num2); break; // Eleva um número a outro
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
            operacaoUso1 = true;
            pontoUso = false;
        }
        // Limpa as variáveis da calculadora.
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            lblVisor.Text   = "0";
            visor           = "0";
            operacaoAtual   = 'x';

            operacaoUso     = false;
            operacaoUso1    = false;
            operacaoUso2    = false;
            igualClique     = false;
            pontoUso        = false;

            num1            = 0;
            num2            = 0;
            result          = 0;            
            memoResult      = 0;
            memoResult1     = 0;
        }
        // Apaga o último número digitado.
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
            if (operacaoUso1 == true)
            {
                num2 = double.Parse(lblVisor.Text);
                memoResult = funcoes();

                if (erro == true)
                {
                    operacaoUso = true;
                    visor = Convert.ToString(memoResult);
                }
                else
                    visor = "ERROR";             
                    
                lblVisor.Text = Convert.ToString(visor);
            }
        }
        private void btnMLimpa_Click(object sender, EventArgs e)
        {
            memoResult = 0;
            memoResult1 = 0;
        }
        private void btnMMostra_Click(object sender, EventArgs e)
        {
            lblVisor.Text = Convert.ToString(memoResult);
            operacaoUso = true;
        }
        private void btnMMais_Click(object sender, EventArgs e)
        {
            memoria();
            memoResult1 += memoResult;
        }
        private void btnMMenos_Click(object sender, EventArgs e)
        {
            memoria();
            memoResult1 -= memoResult;
        }
    }
}
