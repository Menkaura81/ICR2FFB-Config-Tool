package icr2ffbconfig;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.nio.file.Files;
import java.nio.file.Path;
import javax.swing.ImageIcon;
import javax.swing.JOptionPane;
import javax.swing.SpinnerNumberModel;

/**
 *
 * @author Alberto Alarcón López
 */
public class MainDialog extends javax.swing.JFrame {
    
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
    private String spring;
    private String ini;
    private String[] cutted;
    
    
    /**
     * Read ini file
     */
    private void readIniValues(){        
        try {
            // Read ini file
            String RUTA_ENTRADA = System.getProperty("user.dir") + "/ffb.ini";
            ini = Files.readString(Path.of(RUTA_ENTRADA));
            // Separate each line
            cutted = ini.split("\n");
            
            /*
            for (int i = 0; i < cutted.length; i++){
                System.out.println(i + "=" + cutted[i]);
            }*/
            
            // Get values 
            device = cutted[2].substring("Device: ".length());
            game = cutted[5].substring("Game: ".length());
            version = cutted[8].substring("Version: ".length());
            force = Integer.parseInt(cutted[12].substring("Force: ".length()).trim());
            deadzone = Integer.parseInt(cutted[15].substring("Deadzone: ".length()).trim());
            invert = cutted[18].substring("Invert: ".length());
            limit = cutted[21].substring("Limit: ".length());
            constant = cutted[31].substring("Constant: ".length());
            constantScale = Integer.parseInt(cutted[32].substring("Constant Scale: ".length()).trim());
            damper = cutted[35].substring("Damper: ".length());
            damperScale = Integer.parseInt(cutted[36].substring("Damper Scale: ".length()).trim());
            spring = cutted[42].substring("Spring: ".length());
            
            // Clean ini string            
            int pos = cutted[2].indexOf(":");
            cutted[2] = cutted[2].substring(0, pos + 1); 
            pos = cutted[5].indexOf(":");
            cutted[5] = cutted[5].substring(0, pos + 1); 
            pos = cutted[8].indexOf(":");
            cutted[8] = cutted[8].substring(0, pos + 1); 
            pos = cutted[12].indexOf(":");
            cutted[12] = cutted[12].substring(0, pos + 1); 
            pos = cutted[15].indexOf(":");
            cutted[15] = cutted[15].substring(0, pos + 1); 
            pos = cutted[18].indexOf(":");
            cutted[18] = cutted[18].substring(0, pos + 1); 
            pos = cutted[21].indexOf(":");
            cutted[21] = cutted[21].substring(0, pos + 1); 
            pos = cutted[31].indexOf(":");
            cutted[31] = cutted[31].substring(0, pos + 1); 
            pos = cutted[32].indexOf(":");
            cutted[32] = cutted[32].substring(0, pos + 1);
            pos = cutted[35].indexOf(":");
            cutted[35] = cutted[35].substring(0, pos + 1); 
            pos = cutted[36].indexOf(":");
            cutted[36] = cutted[36].substring(0, pos + 1); 
            pos = cutted[42].indexOf(":");
            cutted[42] = cutted[42].substring(0, pos + 1); // incluye el ':'            
        } catch (IOException e) {
            e.printStackTrace();
        }       
    }
    
    
    /**
     * Fills the dialog with the values from the ini file
     */
    private void fillDialog(){
        jTextFieldDevice.setText(device);
        jTextFieldGame.setText(game);
        if (version.equals("DOS4G")){
            jComboBoxVersion.setSelectedIndex(0);
        } else {
            jComboBoxVersion.setSelectedIndex(1);
        }
        jSpinnerForce.setValue(force);
        jSpinnerDeadzone.setValue(deadzone);
        if (invert.equals("false")){
            jComboBoxInvertFFB.setSelectedIndex(0);
        } else {
            jComboBoxInvertFFB.setSelectedIndex(1);
        }
        if (limit.equals("false")){
            jComboBoxLimit.setSelectedIndex(0);
        } else {
            jComboBoxLimit.setSelectedIndex(1);
        }
        if (constant.equals("true")){
            jComboBoxConstant.setSelectedIndex(0);
        } else {
            jComboBoxConstant.setSelectedIndex(1);
        }
        jSpinnerConstantScale.setValue(constantScale);
        if (damper.equals("true")){
            jComboBoxDamper.setSelectedIndex(0);
        } else {
            jComboBoxDamper.setSelectedIndex(1);
        }
        jSpinnerDamperScale.setValue(damperScale);
        if (spring.equals("false")){
            jComboBoxSpring.setSelectedIndex(0);
        } else {
            jComboBoxSpring.setSelectedIndex(1);
        }
    }   
    
    
    /**
     * Write ini file
     */
    private void writeIni() {
        device = jTextFieldDevice.getText();
        game = jTextFieldGame.getText();
        version = jComboBoxVersion.getSelectedItem().toString();
        force = (int) jSpinnerForce.getValue();
        deadzone = (int) jSpinnerDeadzone.getValue();
        invert = jComboBoxInvertFFB.getSelectedItem().toString();
        limit = jComboBoxLimit.getSelectedItem().toString();
        constant = jComboBoxConstant.getSelectedItem().toString();
        constantScale = (int) jSpinnerConstantScale.getValue();
        damper = jComboBoxDamper.getSelectedItem().toString();
        damperScale = (int) jSpinnerDamperScale.getValue();
        spring = jComboBoxSpring.getSelectedItem().toString();

        // Fill the ini string with the values from the screen
        ini = "";
        for (int i = 0; i < cutted.length; i++) {
            ini += cutted[i];
            if (i == 2) {
                ini += " " + device;
            } else if (i == 5) {
                ini += " " + game;
            } else if (i == 8) {
                ini += " " + version;
            } else if (i == 12) {
                ini += " " + force;
            } else if (i == 15) {
                ini += " " + deadzone;
            } else if (i == 18) {
                ini += " " + invert;
            } else if (i == 21) {
                ini += " " + limit;
            } else if (i == 31) {
                ini += " " + constant;
            } else if (i == 32) {
                ini += " " + constantScale;
            } else if (i == 35) {
                ini += " " + damper;
            } else if (i == 36) {
                ini += " " + damperScale;
            } else if (i == 42) {
                ini += " " + spring;
            }
            ini += "\n";
        }

        // Write the file
        FileWriter fichero;
        PrintWriter pw;
        String RUTA_SALIDA = System.getProperty("user.dir") + "/ffb.ini";
        try {
            fichero = new FileWriter(RUTA_SALIDA, false);
            pw = new PrintWriter(fichero);
            pw.print(ini);
            pw.flush();
            pw.close();            
        } catch (IOException e) {
            JOptionPane.showMessageDialog(this,
                    "Error writing ini file",
                    "Warning",
                    JOptionPane.WARNING_MESSAGE);
        }
    }
        
    
    /**
     * Creates new form MainDialog
     */
    public MainDialog() {  
        readIniValues();
        initComponents();
        fillDialog();
    }

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jPanelPluginConfig = new javax.swing.JPanel();
        jLabel9 = new javax.swing.JLabel();
        jTextFieldGame = new javax.swing.JTextField();
        jTextFieldDevice = new javax.swing.JTextField();
        jLabel10 = new javax.swing.JLabel();
        jLabel11 = new javax.swing.JLabel();
        jComboBoxVersion = new javax.swing.JComboBox<>();
        jLabel2 = new javax.swing.JLabel();
        jPanelFFBConfig = new javax.swing.JPanel();
        jLabel5 = new javax.swing.JLabel();
        jSpinnerForce = new javax.swing.JSpinner();
        jLabel6 = new javax.swing.JLabel();
        jSpinnerDeadzone = new javax.swing.JSpinner();
        jLabel7 = new javax.swing.JLabel();
        jComboBoxInvertFFB = new javax.swing.JComboBox<>();
        jLabel8 = new javax.swing.JLabel();
        jComboBoxLimit = new javax.swing.JComboBox<>();
        jLabel3 = new javax.swing.JLabel();
        jPanel1 = new javax.swing.JPanel();
        jLabel4 = new javax.swing.JLabel();
        jLabel12 = new javax.swing.JLabel();
        jComboBoxConstant = new javax.swing.JComboBox<>();
        jLabel13 = new javax.swing.JLabel();
        jSpinnerDamperScale = new javax.swing.JSpinner();
        jLabel14 = new javax.swing.JLabel();
        jComboBoxDamper = new javax.swing.JComboBox<>();
        jLabel15 = new javax.swing.JLabel();
        jSpinnerConstantScale = new javax.swing.JSpinner();
        jLabel16 = new javax.swing.JLabel();
        jComboBoxSpring = new javax.swing.JComboBox<>();
        jPanel2 = new javax.swing.JPanel();
        jButton1 = new javax.swing.JButton();
        jButtonRun = new javax.swing.JButton();
        jLabel1 = new javax.swing.JLabel();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setTitle("ICR2FFB Config");
        setIconImage(new ImageIcon(getClass().getResource("logoGP.png")).getImage());

        jPanelPluginConfig.setBorder(javax.swing.BorderFactory.createEtchedBorder());

        jLabel9.setText("Device:");

        jTextFieldGame.setColumns(15);
        jTextFieldGame.setToolTipText("This can either by 'indycar' or 'cart' depending on what your exe is called (maybe other words too)");

        jTextFieldDevice.setColumns(15);
        jTextFieldDevice.setToolTipText("This should match exactly your device name as you see it in \"Game Controllers\" in windows");

        jLabel10.setText("Game Executable:");

        jLabel11.setText("Version:");

        jComboBoxVersion.setModel(new javax.swing.DefaultComboBoxModel<>(new String[] { "DOS4G", "REND32A" }));
        jComboBoxVersion.setToolTipText("this can either be \"REND32A\" for rendition or \"DOS4G\" for regular dos (sorry no windy yet)");

        jLabel2.setFont(new java.awt.Font("Segoe UI", 1, 12)); // NOI18N
        jLabel2.setText("Plugin Config");

        javax.swing.GroupLayout jPanelPluginConfigLayout = new javax.swing.GroupLayout(jPanelPluginConfig);
        jPanelPluginConfig.setLayout(jPanelPluginConfigLayout);
        jPanelPluginConfigLayout.setHorizontalGroup(
            jPanelPluginConfigLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(jPanelPluginConfigLayout.createSequentialGroup()
                .addContainerGap()
                .addGroup(jPanelPluginConfigLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(jPanelPluginConfigLayout.createSequentialGroup()
                        .addGap(0, 0, Short.MAX_VALUE)
                        .addGroup(jPanelPluginConfigLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, jPanelPluginConfigLayout.createSequentialGroup()
                                .addComponent(jLabel9)
                                .addGap(62, 62, 62))
                            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, jPanelPluginConfigLayout.createSequentialGroup()
                                .addComponent(jLabel10)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED))))
                    .addGroup(jPanelPluginConfigLayout.createSequentialGroup()
                        .addGroup(jPanelPluginConfigLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(jLabel2)
                            .addComponent(jLabel11))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)))
                .addGroup(jPanelPluginConfigLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(jPanelPluginConfigLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                        .addComponent(jTextFieldGame, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addComponent(jTextFieldDevice, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addComponent(jComboBoxVersion, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addContainerGap())
        );
        jPanelPluginConfigLayout.setVerticalGroup(
            jPanelPluginConfigLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, jPanelPluginConfigLayout.createSequentialGroup()
                .addContainerGap()
                .addComponent(jLabel2)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(jPanelPluginConfigLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel9)
                    .addComponent(jTextFieldDevice, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(jPanelPluginConfigLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel10)
                    .addComponent(jTextFieldGame, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(jPanelPluginConfigLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel11)
                    .addComponent(jComboBoxVersion, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addContainerGap(22, Short.MAX_VALUE))
        );

        jPanelFFBConfig.setBorder(javax.swing.BorderFactory.createEtchedBorder());

        jLabel5.setText("Force:");

        jSpinnerForce.setModel(new SpinnerNumberModel(25, 1, 100, 1));
        jSpinnerForce.setToolTipText("PLEASE BE CAREFUL");

        jLabel6.setText("DeadZone:");

        jSpinnerDeadzone.setModel(new SpinnerNumberModel(0, 0, 100, 1));

        jLabel7.setText("Invert FFB:");

        jComboBoxInvertFFB.setModel(new javax.swing.DefaultComboBoxModel<>(new String[] { "false", "true" }));

        jLabel8.setText("Limit:");

        jComboBoxLimit.setModel(new javax.swing.DefaultComboBoxModel<>(new String[] { "false", "true" }));

        jLabel3.setFont(new java.awt.Font("Segoe UI", 1, 12)); // NOI18N
        jLabel3.setText("FFB Config");

        javax.swing.GroupLayout jPanelFFBConfigLayout = new javax.swing.GroupLayout(jPanelFFBConfig);
        jPanelFFBConfig.setLayout(jPanelFFBConfigLayout);
        jPanelFFBConfigLayout.setHorizontalGroup(
            jPanelFFBConfigLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(jPanelFFBConfigLayout.createSequentialGroup()
                .addContainerGap()
                .addGroup(jPanelFFBConfigLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(jPanelFFBConfigLayout.createSequentialGroup()
                        .addGroup(jPanelFFBConfigLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(jLabel7)
                            .addComponent(jLabel8))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addGroup(jPanelFFBConfigLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(jComboBoxLimit, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(jComboBoxInvertFFB, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)))
                    .addGroup(jPanelFFBConfigLayout.createSequentialGroup()
                        .addGroup(jPanelFFBConfigLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(jLabel6)
                            .addComponent(jLabel5))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addGroup(jPanelFFBConfigLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(jSpinnerForce, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(jSpinnerDeadzone, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)))
                    .addComponent(jLabel3))
                .addContainerGap(11, Short.MAX_VALUE))
        );
        jPanelFFBConfigLayout.setVerticalGroup(
            jPanelFFBConfigLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, jPanelFFBConfigLayout.createSequentialGroup()
                .addContainerGap()
                .addComponent(jLabel3)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(jPanelFFBConfigLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel5)
                    .addComponent(jSpinnerForce, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(jPanelFFBConfigLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jSpinnerDeadzone, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(jLabel6))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(jPanelFFBConfigLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel7)
                    .addComponent(jComboBoxInvertFFB, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(jPanelFFBConfigLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel8)
                    .addComponent(jComboBoxLimit, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );

        jPanel1.setBorder(javax.swing.BorderFactory.createEtchedBorder());

        jLabel4.setFont(new java.awt.Font("Segoe UI", 1, 12)); // NOI18N
        jLabel4.setText("Effects Mix");

        jLabel12.setText("Constant:");

        jComboBoxConstant.setModel(new javax.swing.DefaultComboBoxModel<>(new String[] { "true", "false" }));

        jLabel13.setText("Scale:");

        jSpinnerDamperScale.setModel(new SpinnerNumberModel(50, 1, 100, 1));

        jLabel14.setText("Damper:");

        jComboBoxDamper.setModel(new javax.swing.DefaultComboBoxModel<>(new String[] { "true", "false" }));

        jLabel15.setText("Scale:");

        jSpinnerConstantScale.setModel(new SpinnerNumberModel(100, 1, 100, 1));

        jLabel16.setText("Spring (Legacy):");

        jComboBoxSpring.setModel(new javax.swing.DefaultComboBoxModel<>(new String[] { "false", "true" }));

        javax.swing.GroupLayout jPanel1Layout = new javax.swing.GroupLayout(jPanel1);
        jPanel1.setLayout(jPanel1Layout);
        jPanel1Layout.setHorizontalGroup(
            jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(jPanel1Layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(jLabel4)
                    .addGroup(jPanel1Layout.createSequentialGroup()
                        .addComponent(jLabel12)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(jComboBoxConstant, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(jLabel13)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(jSpinnerConstantScale, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(jPanel1Layout.createSequentialGroup()
                        .addComponent(jLabel14)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addComponent(jComboBoxDamper, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(jLabel15)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(jSpinnerDamperScale, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(jPanel1Layout.createSequentialGroup()
                        .addComponent(jLabel16)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(jComboBoxSpring, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)))
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );
        jPanel1Layout.setVerticalGroup(
            jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(jPanel1Layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(jLabel4)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel12)
                    .addComponent(jComboBoxConstant, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(jLabel13)
                    .addComponent(jSpinnerConstantScale, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel14)
                    .addComponent(jComboBoxDamper, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(jLabel15)
                    .addComponent(jSpinnerDamperScale, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel16)
                    .addComponent(jComboBoxSpring, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );

        jButton1.setText("Save config");
        jButton1.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButton1ActionPerformed(evt);
            }
        });

        jButtonRun.setText("Run");
        jButtonRun.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButtonRunActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout jPanel2Layout = new javax.swing.GroupLayout(jPanel2);
        jPanel2.setLayout(jPanel2Layout);
        jPanel2Layout.setHorizontalGroup(
            jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(jPanel2Layout.createSequentialGroup()
                .addGap(55, 55, 55)
                .addGroup(jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                    .addComponent(jButtonRun, javax.swing.GroupLayout.PREFERRED_SIZE, 106, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(jButton1, javax.swing.GroupLayout.PREFERRED_SIZE, 106, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );
        jPanel2Layout.setVerticalGroup(
            jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(jPanel2Layout.createSequentialGroup()
                .addGap(18, 18, 18)
                .addComponent(jButton1, javax.swing.GroupLayout.PREFERRED_SIZE, 50, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(jButtonRun, javax.swing.GroupLayout.PREFERRED_SIZE, 48, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );

        jLabel1.setText("ICR2FFB Plugin by GPLaps | Config UI by Menkaura");

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(jPanelFFBConfig, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(jPanelPluginConfig, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(jPanel1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(jPanel2, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)))
                .addContainerGap())
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(jLabel1)
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                    .addComponent(jPanelFFBConfig, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .addComponent(jPanelPluginConfig, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                    .addComponent(jPanel1, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .addComponent(jPanel2, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addComponent(jLabel1)
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void jButton1ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButton1ActionPerformed
        if (jTextFieldDevice.getText().isEmpty() || jTextFieldGame.getText().isEmpty()) {
            JOptionPane.showMessageDialog(this,
                "Device or Game field is empty",
                "Warning",
                JOptionPane.WARNING_MESSAGE);
        } else {
            writeIni();
            JOptionPane.showMessageDialog(this,
                    "Ini file saved",
                    "Success",
                    JOptionPane.INFORMATION_MESSAGE);
        }
    }//GEN-LAST:event_jButton1ActionPerformed

    private void jButtonRunActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButtonRunActionPerformed
        // Save ini before launch
        writeIni();

        // Launch exe
        try {
            //String rutaExe = System.getProperty("user.dir") + File.separator + "ICR2FFB.exe";
            String folder = System.getProperty("user.dir");
            
            // Launch exe
            //Runtime.getRuntime().exec(rutaExe);
            Runtime.getRuntime().exec(
            new String[] { "cmd", "/c", "start", "ICR2FFB.exe" },
            null,
            new File(folder)
            );
            System.out.println("Programa ejecutado correctamente.");
        } catch (IOException e) {
            e.printStackTrace();
        }
    }//GEN-LAST:event_jButtonRunActionPerformed
    
    
    /**
     * @param args the command line arguments
     */
    public static void main(String args[]) {
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(MainDialog.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(MainDialog.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(MainDialog.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(MainDialog.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {                
                MainDialog dialog = new MainDialog();
                dialog.setLocationRelativeTo(null); // <-- centra en la pantalla
                dialog.setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton jButton1;
    private javax.swing.JButton jButtonRun;
    private javax.swing.JComboBox<String> jComboBoxConstant;
    private javax.swing.JComboBox<String> jComboBoxDamper;
    private javax.swing.JComboBox<String> jComboBoxInvertFFB;
    private javax.swing.JComboBox<String> jComboBoxLimit;
    private javax.swing.JComboBox<String> jComboBoxSpring;
    private javax.swing.JComboBox<String> jComboBoxVersion;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel10;
    private javax.swing.JLabel jLabel11;
    private javax.swing.JLabel jLabel12;
    private javax.swing.JLabel jLabel13;
    private javax.swing.JLabel jLabel14;
    private javax.swing.JLabel jLabel15;
    private javax.swing.JLabel jLabel16;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JLabel jLabel3;
    private javax.swing.JLabel jLabel4;
    private javax.swing.JLabel jLabel5;
    private javax.swing.JLabel jLabel6;
    private javax.swing.JLabel jLabel7;
    private javax.swing.JLabel jLabel8;
    private javax.swing.JLabel jLabel9;
    private javax.swing.JPanel jPanel1;
    private javax.swing.JPanel jPanel2;
    private javax.swing.JPanel jPanelFFBConfig;
    private javax.swing.JPanel jPanelPluginConfig;
    private javax.swing.JSpinner jSpinnerConstantScale;
    private javax.swing.JSpinner jSpinnerDamperScale;
    private javax.swing.JSpinner jSpinnerDeadzone;
    private javax.swing.JSpinner jSpinnerForce;
    private javax.swing.JTextField jTextFieldDevice;
    private javax.swing.JTextField jTextFieldGame;
    // End of variables declaration//GEN-END:variables
}
