using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection.Metadata;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        String[] iniLines;

        private String device;
        private String game;
        private String version;
        private int force;
        private int deadzone;
        private String invert;
        private String limit;
        private String constant;
        private int constantScale;
        private String damper;
        private int damperScale;
        private int brakingScale;
        private String spring;

        // values line in .ini file
        private readonly int DEVICE_LINE = 2;
        private readonly int GAME_LINE = 6;
        private readonly int VERSION_LINE = 9;
        private readonly int FORCE_LINE = 13;
        private readonly int DEADZONE_LINE = 16;
        private readonly int INVERT_LINE = 19;
        private readonly int LIMIT_LINE = 22;
        private readonly int CONSTANT_LINE = 32;
        private readonly int CONSTANT_SCALE_LINE = 33;
        private readonly int BRAKING_SCALE_LINE = 36;
        private readonly int DAMPER_LINE = 39;
        private readonly int DAMPER_SCALE_LINE = 40;
        private readonly int SPRING_LINE = 46;

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            readIni();
            fillDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void readIni()
        {
            iniLines = File.ReadAllLines("ffb.ini");

            // File read check
            /*
            for (int i = 0; i < iniLines.Length; i++)
            {
                Debug.WriteLine($"{i}: {iniLines[i]}");
            }
            */

            // Get values 
            device = iniLines[DEVICE_LINE].Substring("Device: ".Length).Trim();
            game = iniLines[GAME_LINE].Substring("Game: ".Length).Trim();
            version = iniLines[VERSION_LINE].Substring("Version: ".Length).Trim();
            force = int.Parse(iniLines[FORCE_LINE].Substring("Force: ".Length).Trim());
            deadzone = int.Parse(iniLines[DEADZONE_LINE].Substring("Deadzone: ".Length).Trim());
            invert = iniLines[INVERT_LINE].Substring("Invert: ".Length);
            limit = iniLines[LIMIT_LINE].Substring("Limit: ".Length);
            constant = iniLines[CONSTANT_LINE].Substring("Constant: ".Length);
            constantScale = int.Parse(iniLines[CONSTANT_SCALE_LINE].Substring("Constant Scale: ".Length).Trim());
            brakingScale = int.Parse(iniLines[BRAKING_SCALE_LINE].Substring("Braking Scale: ".Length).Trim());
            damper = iniLines[DAMPER_LINE].Substring("Damper: ".Length);
            damperScale = int.Parse(iniLines[DAMPER_SCALE_LINE].Substring("Damper Scale: ".Length).Trim());
            spring = iniLines[SPRING_LINE].Substring("Spring: ".Length);

            // Clean ini string            
            int pos = iniLines[DEVICE_LINE].IndexOf(":");
            iniLines[DEVICE_LINE] = iniLines[DEVICE_LINE].Substring(0, pos + 1);
            pos = iniLines[GAME_LINE].IndexOf(":");
            iniLines[GAME_LINE] = iniLines[GAME_LINE].Substring(0, pos + 1);
            pos = iniLines[VERSION_LINE].IndexOf(":");
            iniLines[VERSION_LINE] = iniLines[VERSION_LINE].Substring(0, pos + 1);
            pos = iniLines[FORCE_LINE].IndexOf(":");
            iniLines[FORCE_LINE] = iniLines[FORCE_LINE].Substring(0, pos + 1);
            pos = iniLines[DEADZONE_LINE].IndexOf(":");
            iniLines[DEADZONE_LINE] = iniLines[DEADZONE_LINE].Substring(0, pos + 1);
            pos = iniLines[INVERT_LINE].IndexOf(":");
            iniLines[INVERT_LINE] = iniLines[INVERT_LINE].Substring(0, pos + 1);
            pos = iniLines[LIMIT_LINE].IndexOf(":");
            iniLines[LIMIT_LINE] = iniLines[LIMIT_LINE].Substring(0, pos + 1);
            pos = iniLines[CONSTANT_LINE].IndexOf(":");
            iniLines[CONSTANT_LINE] = iniLines[CONSTANT_LINE].Substring(0, pos + 1);
            pos = iniLines[CONSTANT_SCALE_LINE].IndexOf(":");
            iniLines[CONSTANT_SCALE_LINE] = iniLines[CONSTANT_SCALE_LINE].Substring(0, pos + 1);
            pos = iniLines[BRAKING_SCALE_LINE].IndexOf(":");
            iniLines[BRAKING_SCALE_LINE] = iniLines[BRAKING_SCALE_LINE].Substring(0, pos + 1);
            pos = iniLines[DAMPER_LINE].IndexOf(":");
            iniLines[DAMPER_LINE] = iniLines[DAMPER_LINE].Substring(0, pos + 1);
            pos = iniLines[DAMPER_SCALE_LINE].IndexOf(":");
            iniLines[DAMPER_SCALE_LINE] = iniLines[DAMPER_SCALE_LINE].Substring(0, pos + 1);
            pos = iniLines[SPRING_LINE].IndexOf(":");
            iniLines[SPRING_LINE] = iniLines[SPRING_LINE].Substring(0, pos + 1); // incluye el ':'

            // Clean ini check
            /* 
            for (int i = 0; i < iniLines.Length; i++)
            {
                Debug.WriteLine($"{i}: {iniLines[i]}");
            }
            */
        }                


        private void fillDialog()
        {
            textBoxDevice.Text = device;
            textBoxGame.Text = game;
            if (version.Equals("DOS4G"))
            {
                comboBoxVersion.SelectedIndex = 0;
            }
            else
            {
                comboBoxVersion.SelectedIndex = 1;
            }
            numericUpDownForce.Value = force;
            numericUpDownDeadzone.Value = deadzone;
            if (invert.Equals("false"))
            {
                comboBoxInvertFFB.SelectedIndex = 0;
            }
            else
            {
                comboBoxInvertFFB.SelectedIndex = 1;
            }
            if (limit.Equals("false"))
            {
                comboBoxLimit.SelectedIndex = 0;
            }
            else
            {
                comboBoxLimit.SelectedIndex = 1;
            }           
            if (constant.Equals("true"))
            {
                comboBoxConstant.SelectedIndex = 1;
            }
            else
            {
                comboBoxConstant.SelectedIndex = 0;
            }
            numericUpDownConstantScale.Value = constantScale;
            numericUpDownBrakingScale.Value = brakingScale;            
            if (damper.Equals("true"))
            {
                comboBoxDamper.SelectedIndex = 1;
            }
            else
            {
                comboBoxDamper.SelectedIndex = 0;
            }
            numericUpDownDamperScale.Value = damperScale;
            if (spring.Equals("false"))
            {
                comboBoxSpring.SelectedIndex = 0;
            }
            else
            {
                comboBoxSpring.SelectedIndex = 1;
            }
        }


        private void writeIni()
        {

        }


        private void buttonRun_Click(object sender, EventArgs e)
        {
            string nombreArchivo = "ICR2FFB.exe";
            try
            {
                Debug.WriteLine("Trying to run ICR2FFB.exe...");

                // Admin rights
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = nombreArchivo,
                    UseShellExecute = true,
                    Verb = "runas"
                };

                Process proceso = Process.Start(startInfo);

                if (proceso != null)
                {
                    Debug.WriteLine($"✓ ÉXITO: ICR2FFB iniciado como administrador con ID: {proceso.Id}");
                }
                else
                {
                    Debug.WriteLine("❌ El proceso no se pudo iniciar (¿usuario canceló UAC?)");
                }
            }
            catch (Win32Exception ex)
            {
                Debug.WriteLine($"❌ Win32Exception: {ex.Message}");
                Debug.WriteLine($"Código de error nativo: {ex.NativeErrorCode}");

                switch (ex.NativeErrorCode)
                {
                    case 1223: // ERROR_CANCELLED
                        Debug.WriteLine("💡 CAUSA: Usuario canceló la solicitud de UAC");
                        Debug.WriteLine("💡 SOLUCIÓN: Aceptar la ventana de UAC para que ICR2FFB funcione");
                        break;
                    case 2: // ERROR_FILE_NOT_FOUND
                        Debug.WriteLine("💡 CAUSA: ICR2FFB.exe no encontrado");
                        Debug.WriteLine("💡 SOLUCIÓN: Verificar que ICR2FFB.exe está en la carpeta correcta");
                        break;
                    case 5: // ERROR_ACCESS_DENIED
                        Debug.WriteLine("💡 CAUSA: Acceso denegado");
                        Debug.WriteLine("💡 SOLUCIÓN: Ejecutar Visual Studio como administrador");
                        break;
                    case 193: // ERROR_BAD_EXE_FORMAT
                        Debug.WriteLine("💡 CAUSA: ICR2FFB.exe corrupto o formato inválido");
                        Debug.WriteLine("💡 SOLUCIÓN: Descargar ICR2FFB nuevamente");
                        break;
                    default:
                        Debug.WriteLine($"💡 Error desconocido. Código: {ex.NativeErrorCode}");
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ Error general: {ex.Message}");
                Debug.WriteLine($"Tipo: {ex.GetType().Name}");
            }
        }
    }
}
