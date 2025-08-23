using System.ComponentModel;
using System.Diagnostics;
using SharpDX.DirectInput;

namespace WinFormsApp1
{
    public partial class MainDialog : Form
    {
        // ini file lines
        String[] iniLines;
        // ini values
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
        // DirectInput
        private static DirectInput directInput;
        private static IList<DeviceInstance> devices;


        /**
         * Main dialog constructor
         */
        public MainDialog()
        {
            // Initialize the form components
            InitializeComponent();
            // Center the dialog in the screen
            this.StartPosition = FormStartPosition.CenterScreen;
            // Fixed size dialog
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false; // No maximize button
            readIni();
            readDirectInputDevices();
            fillDialog();
        }


        /**
         * Read DirectInput devices and fill the comboBoxDirectInput
         */
        private void readDirectInputDevices()
        {
            try
            {
                Debug.WriteLine($"Searching devices: {device}");

                // IMPORTANTE: Liberar DirectInput anterior si existe
                if (directInput != null)
                {
                    directInput.Dispose();
                    directInput = null;
                }

                // Inicializar DirectInput
                directInput = new DirectInput();
                // Enum all devices
                var allDevices = directInput.GetDevices(DeviceClass.GameControl, DeviceEnumerationFlags.AllDevices);
                // Filter only connected devices 
                devices = allDevices.Where(d => d.Type != DeviceType.Mouse && d.Type != DeviceType.Keyboard).ToList();

                // Clean ComboBox
                comboBoxDirectInput.Items.Clear();
                comboBoxDirectInput.SelectedIndex = -1; // Asegurar que no hay selección
                comboBoxDirectInput.Text = string.Empty;

                // Check if any device found
                if (devices == null || !devices.Any())
                {
                    comboBoxDirectInput.Text = "No devices found";
                    Debug.WriteLine("No DirectInput devices found");
                    return;
                }

                // Fill ComboBox with device names
                foreach (var deviceInstance in devices)
                {
                    Debug.WriteLine($"Device found: {deviceInstance.ProductName}");
                    comboBoxDirectInput.Items.Add(deviceInstance.ProductName);
                }

                // Search and select the device from ini file
                bool deviceFound = false;
                if (!string.IsNullOrEmpty(device))
                {
                    for (int i = 0; i < comboBoxDirectInput.Items.Count; i++)
                    {
                        if (comboBoxDirectInput.Items[i].ToString().Equals(device))
                        {
                            comboBoxDirectInput.SelectedIndex = i;
                            deviceFound = true;
                            Debug.WriteLine($"Device selected: {device}");
                            break;
                        }
                    }
                }

                // Manejar caso cuando no se encuentra el dispositivo
                if (!deviceFound)
                {
                    if (comboBoxDirectInput.Items.Count > 0)
                    {
                        comboBoxDirectInput.Text = "ini device not found";
                    }
                    else
                    {
                        comboBoxDirectInput.Text = "No devices connected";
                    }
                    Debug.WriteLine("ini device not found");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error reading DirectInput devices: {ex.Message}");
                comboBoxDirectInput.Items.Clear();
                comboBoxDirectInput.Text = "Error reading devices";
            }
        }


        /**
         * Read ffb.ini file and get the values
         */
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


        /**
         * Fill the dialog with the values read from ffb.ini
         */
        private void fillDialog()
        {
            // comboBoxDirectInput.SelectedItem = device;
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


        /**
         * Write the screen values to ffb.ini
         */
        private void writeIni()
        {
            device = comboBoxDirectInput.SelectedItem.ToString();
            game = textBoxGame.Text.Trim();
            version = comboBoxVersion.SelectedItem.ToString();
            force = (int)numericUpDownForce.Value;
            deadzone = (int)numericUpDownDeadzone.Value;
            invert = comboBoxInvertFFB.SelectedItem.ToString();
            limit = comboBoxLimit.SelectedItem.ToString();
            constant = comboBoxConstant.SelectedItem.ToString();
            constantScale = (int)numericUpDownConstantScale.Value;
            brakingScale = (int)numericUpDownBrakingScale.Value;
            damper = comboBoxDamper.SelectedItem.ToString();
            damperScale = (int)numericUpDownDamperScale.Value;
            spring = comboBoxSpring.SelectedItem.ToString();

            // Fill the ini string with the values from the screen
            String ini = "";
            for (int i = 0; i < iniLines.Length; i++)
            {
                ini += iniLines[i];
                if (i == DEVICE_LINE)
                {
                    ini += " " + device;
                }
                else if (i == GAME_LINE)
                {
                    ini += " " + game;
                }
                else if (i == VERSION_LINE)
                {
                    ini += " " + version;
                }
                else if (i == FORCE_LINE)
                {
                    ini += " " + force;
                }
                else if (i == DEADZONE_LINE)
                {
                    ini += " " + deadzone;
                }
                else if (i == INVERT_LINE)
                {
                    ini += " " + invert;
                }
                else if (i == LIMIT_LINE)
                {
                    ini += " " + limit;
                }
                else if (i == CONSTANT_LINE)
                {
                    ini += " " + constant;
                }
                else if (i == CONSTANT_SCALE_LINE)
                {
                    ini += " " + constantScale;
                }
                else if (i == BRAKING_SCALE_LINE)
                {
                    ini += " " + brakingScale;
                }
                else if (i == DAMPER_LINE)
                {
                    ini += " " + damper;
                }
                else if (i == DAMPER_SCALE_LINE)
                {
                    ini += " " + damperScale;
                }
                else if (i == SPRING_LINE)
                {
                    ini += " " + spring;
                }
                ini += "\n";
            }

            // Write the file
            string RUTA_SALIDA = Directory.GetCurrentDirectory() + "/ffb.ini";
            try
            {
                File.WriteAllText(RUTA_SALIDA, ini);
                MessageBox.Show("ini file saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error writing ini file", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        /**
         * Launch ICR2FFB.exe with admin rights
         */
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
                    Debug.WriteLine($"✓ SUCCESS: ICR2FFB started as administrator with ID: {proceso.Id}");
                }
                else
                {
                    Debug.WriteLine("❌ The process could not be started (did user cancel UAC?)");
                }
            }
            catch (Win32Exception ex)
            {
                Debug.WriteLine($"❌ Win32Exception: {ex.Message}");
                Debug.WriteLine($"Native error code: {ex.NativeErrorCode}");
                switch (ex.NativeErrorCode)
                {
                    case 1223: // ERROR_CANCELLED
                        Debug.WriteLine("💡 CAUSE: User cancelled UAC request");
                        Debug.WriteLine("💡 SOLUTION: Accept the UAC window for ICR2FFB to work");
                        break;
                    case 2: // ERROR_FILE_NOT_FOUND
                        Debug.WriteLine("💡 CAUSE: ICR2FFB.exe not found");
                        Debug.WriteLine("💡 SOLUTION: Verify that ICR2FFB.exe is in the correct folder");
                        break;
                    case 5: // ERROR_ACCESS_DENIED
                        Debug.WriteLine("💡 CAUSE: Access denied");
                        Debug.WriteLine("💡 SOLUTION: Run Visual Studio as administrator");
                        break;
                    case 193: // ERROR_BAD_EXE_FORMAT
                        Debug.WriteLine("💡 CAUSE: ICR2FFB.exe corrupted or invalid format");
                        Debug.WriteLine("💡 SOLUTION: Download ICR2FFB again");
                        break;
                    default:
                        Debug.WriteLine($"💡 Unknown error. Code: {ex.NativeErrorCode}");
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ General error: {ex.Message}");
                Debug.WriteLine($"Type: {ex.GetType().Name}");
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxGame.Text))
            {
                MessageBox.Show("Game field is empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                writeIni();
            }
        }


        /**
         * Button for Refreshing DirectInput devices
         */
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            readDirectInputDevices();            
        }


        /**
         * Dispose DirectInput on form closing
         */
        private void MainDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Dispose DirectInput
            if (directInput != null)
            {
                directInput.Dispose();
                directInput = null;
            }
        }
    }
}
