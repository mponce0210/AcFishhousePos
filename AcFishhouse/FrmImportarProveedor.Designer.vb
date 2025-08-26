<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImportarProveedor
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.cmbProveedor = New System.Windows.Forms.ComboBox()
        Me.BtnDescargarPlantilla = New System.Windows.Forms.Button()
        Me.txtArchivo = New System.Windows.Forms.TextBox()
        Me.BtnExaminar = New System.Windows.Forms.Button()
        Me.lblArchivoInfo = New System.Windows.Forms.Label()
        Me.grpOrigen = New System.Windows.Forms.GroupBox()
        Me.chkReemplazoTotal = New System.Windows.Forms.CheckBox()
        Me.chkValidacionrapida = New System.Windows.Forms.CheckBox()
        Me.lblProveedortip = New System.Windows.Forms.Label()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tabPreview = New System.Windows.Forms.TabPage()
        Me.dgvPreview = New System.Windows.Forms.DataGridView()
        Me.tabErrores = New System.Windows.Forms.TabPage()
        Me.lblErroresResumen = New System.Windows.Forms.Label()
        Me.dvgErrores = New System.Windows.Forms.DataGridView()
        Me.RowNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Campo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MensajeError = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tablog = New System.Windows.Forms.TabPage()
        Me.txtlog = New System.Windows.Forms.TextBox()
        Me.grpResumen = New System.Windows.Forms.GroupBox()
        Me.prgProgreso = New System.Windows.Forms.ProgressBar()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.BtnRollBack = New System.Windows.Forms.Button()
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.btnvalidar = New System.Windows.Forms.Button()
        Me.lblestadoImport = New System.Windows.Forms.Label()
        Me.lblEliminados = New System.Windows.Forms.Label()
        Me.lblActualizados = New System.Windows.Forms.Label()
        Me.LblInsertadas = New System.Windows.Forms.Label()
        Me.lblFilasValidad = New System.Windows.Forms.Label()
        Me.lblFilasLeidas = New System.Windows.Forms.Label()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.tssUsuario = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssProveedor = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssBatch = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssImportId = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.grpOrigen.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tabPreview.SuspendLayout()
        CType(Me.dgvPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabErrores.SuspendLayout()
        CType(Me.dvgErrores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tablog.SuspendLayout()
        Me.grpResumen.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Location = New System.Drawing.Point(171, 33)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(161, 13)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Importar Archivos del Proveedor "
        '
        'cmbProveedor
        '
        Me.cmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProveedor.FormattingEnabled = True
        Me.cmbProveedor.Location = New System.Drawing.Point(133, 49)
        Me.cmbProveedor.Name = "cmbProveedor"
        Me.cmbProveedor.Size = New System.Drawing.Size(236, 21)
        Me.cmbProveedor.TabIndex = 1
        '
        'BtnDescargarPlantilla
        '
        Me.BtnDescargarPlantilla.Location = New System.Drawing.Point(174, 76)
        Me.BtnDescargarPlantilla.Name = "BtnDescargarPlantilla"
        Me.BtnDescargarPlantilla.Size = New System.Drawing.Size(121, 23)
        Me.BtnDescargarPlantilla.TabIndex = 2
        Me.BtnDescargarPlantilla.Text = "Descargar Plantilla"
        Me.BtnDescargarPlantilla.UseVisualStyleBackColor = True
        '
        'txtArchivo
        '
        Me.txtArchivo.Location = New System.Drawing.Point(133, 105)
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.ReadOnly = True
        Me.txtArchivo.Size = New System.Drawing.Size(236, 20)
        Me.txtArchivo.TabIndex = 3
        '
        'BtnExaminar
        '
        Me.BtnExaminar.Location = New System.Drawing.Point(174, 131)
        Me.BtnExaminar.Name = "BtnExaminar"
        Me.BtnExaminar.Size = New System.Drawing.Size(121, 23)
        Me.BtnExaminar.TabIndex = 4
        Me.BtnExaminar.Text = "Examinar ... "
        Me.BtnExaminar.UseVisualStyleBackColor = True
        '
        'lblArchivoInfo
        '
        Me.lblArchivoInfo.AutoSize = True
        Me.lblArchivoInfo.Location = New System.Drawing.Point(183, 170)
        Me.lblArchivoInfo.Name = "lblArchivoInfo"
        Me.lblArchivoInfo.Size = New System.Drawing.Size(41, 13)
        Me.lblArchivoInfo.TabIndex = 5
        Me.lblArchivoInfo.Text = "InfoCor"
        '
        'grpOrigen
        '
        Me.grpOrigen.Controls.Add(Me.lblTitulo)
        Me.grpOrigen.Controls.Add(Me.lblArchivoInfo)
        Me.grpOrigen.Controls.Add(Me.cmbProveedor)
        Me.grpOrigen.Controls.Add(Me.BtnExaminar)
        Me.grpOrigen.Controls.Add(Me.BtnDescargarPlantilla)
        Me.grpOrigen.Controls.Add(Me.txtArchivo)
        Me.grpOrigen.Location = New System.Drawing.Point(12, 26)
        Me.grpOrigen.Name = "grpOrigen"
        Me.grpOrigen.Size = New System.Drawing.Size(463, 207)
        Me.grpOrigen.TabIndex = 6
        Me.grpOrigen.TabStop = False
        Me.grpOrigen.Text = "Origen del Archivo"
        '
        'chkReemplazoTotal
        '
        Me.chkReemplazoTotal.AutoSize = True
        Me.chkReemplazoTotal.Location = New System.Drawing.Point(198, 262)
        Me.chkReemplazoTotal.Name = "chkReemplazoTotal"
        Me.chkReemplazoTotal.Size = New System.Drawing.Size(286, 17)
        Me.chkReemplazoTotal.TabIndex = 7
        Me.chkReemplazoTotal.Text = "Reemplazo total ( Trunca Produccion y CargaArchivo ) "
        Me.chkReemplazoTotal.UseVisualStyleBackColor = True
        '
        'chkValidacionrapida
        '
        Me.chkValidacionrapida.AutoSize = True
        Me.chkValidacionrapida.Location = New System.Drawing.Point(198, 285)
        Me.chkValidacionrapida.Name = "chkValidacionrapida"
        Me.chkValidacionrapida.Size = New System.Drawing.Size(181, 17)
        Me.chkValidacionrapida.TabIndex = 8
        Me.chkValidacionrapida.Text = "Validacion Rapida ( Sin commit ) "
        Me.chkValidacionrapida.UseVisualStyleBackColor = True
        '
        'lblProveedortip
        '
        Me.lblProveedortip.AutoSize = True
        Me.lblProveedortip.Location = New System.Drawing.Point(197, 314)
        Me.lblProveedortip.Name = "lblProveedortip"
        Me.lblProveedortip.Size = New System.Drawing.Size(286, 13)
        Me.lblProveedortip.TabIndex = 9
        Me.lblProveedortip.Text = "Se usara Mapeo de Columnas del Proveedor Seleccionado"
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tabPreview)
        Me.TabMain.Controls.Add(Me.tabErrores)
        Me.TabMain.Controls.Add(Me.tablog)
        Me.TabMain.Location = New System.Drawing.Point(36, 350)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(899, 215)
        Me.TabMain.TabIndex = 10
        Me.TabMain.Tag = "Vista Previa"
        '
        'tabPreview
        '
        Me.tabPreview.Controls.Add(Me.dgvPreview)
        Me.tabPreview.Location = New System.Drawing.Point(4, 22)
        Me.tabPreview.Name = "tabPreview"
        Me.tabPreview.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPreview.Size = New System.Drawing.Size(891, 189)
        Me.tabPreview.TabIndex = 0
        Me.tabPreview.Text = "Vista Previa"
        Me.tabPreview.UseVisualStyleBackColor = True
        '
        'dgvPreview
        '
        Me.dgvPreview.AllowUserToAddRows = False
        Me.dgvPreview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPreview.Location = New System.Drawing.Point(27, 19)
        Me.dgvPreview.Name = "dgvPreview"
        Me.dgvPreview.ReadOnly = True
        Me.dgvPreview.Size = New System.Drawing.Size(844, 147)
        Me.dgvPreview.TabIndex = 0
        '
        'tabErrores
        '
        Me.tabErrores.Controls.Add(Me.lblErroresResumen)
        Me.tabErrores.Controls.Add(Me.dvgErrores)
        Me.tabErrores.Location = New System.Drawing.Point(4, 22)
        Me.tabErrores.Name = "tabErrores"
        Me.tabErrores.Padding = New System.Windows.Forms.Padding(3)
        Me.tabErrores.Size = New System.Drawing.Size(891, 189)
        Me.tabErrores.TabIndex = 1
        Me.tabErrores.Text = "Errores"
        Me.tabErrores.UseVisualStyleBackColor = True
        '
        'lblErroresResumen
        '
        Me.lblErroresResumen.AutoSize = True
        Me.lblErroresResumen.Location = New System.Drawing.Point(600, 13)
        Me.lblErroresResumen.Name = "lblErroresResumen"
        Me.lblErroresResumen.Size = New System.Drawing.Size(140, 13)
        Me.lblErroresResumen.TabIndex = 1
        Me.lblErroresResumen.Text = "Errores : 0 / Advertencias: 0"
        '
        'dvgErrores
        '
        Me.dvgErrores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dvgErrores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RowNum, Me.Campo, Me.MensajeError})
        Me.dvgErrores.Location = New System.Drawing.Point(18, 39)
        Me.dvgErrores.Name = "dvgErrores"
        Me.dvgErrores.ReadOnly = True
        Me.dvgErrores.Size = New System.Drawing.Size(852, 128)
        Me.dvgErrores.TabIndex = 0
        '
        'RowNum
        '
        Me.RowNum.HeaderText = "Renglones"
        Me.RowNum.Name = "RowNum"
        Me.RowNum.ReadOnly = True
        '
        'Campo
        '
        Me.Campo.HeaderText = "Campo"
        Me.Campo.Name = "Campo"
        Me.Campo.ReadOnly = True
        '
        'MensajeError
        '
        Me.MensajeError.HeaderText = "Mensaje Error"
        Me.MensajeError.Name = "MensajeError"
        Me.MensajeError.ReadOnly = True
        '
        'tablog
        '
        Me.tablog.Controls.Add(Me.txtlog)
        Me.tablog.Location = New System.Drawing.Point(4, 22)
        Me.tablog.Name = "tablog"
        Me.tablog.Padding = New System.Windows.Forms.Padding(3)
        Me.tablog.Size = New System.Drawing.Size(891, 189)
        Me.tablog.TabIndex = 2
        Me.tablog.Text = "Bitacora"
        Me.tablog.UseVisualStyleBackColor = True
        '
        'txtlog
        '
        Me.txtlog.Location = New System.Drawing.Point(69, 32)
        Me.txtlog.Multiline = True
        Me.txtlog.Name = "txtlog"
        Me.txtlog.ReadOnly = True
        Me.txtlog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtlog.Size = New System.Drawing.Size(772, 136)
        Me.txtlog.TabIndex = 0
        Me.txtlog.Text = "Evantos paso a paso"
        '
        'grpResumen
        '
        Me.grpResumen.Controls.Add(Me.prgProgreso)
        Me.grpResumen.Controls.Add(Me.btnCerrar)
        Me.grpResumen.Controls.Add(Me.BtnRollBack)
        Me.grpResumen.Controls.Add(Me.btnProcesar)
        Me.grpResumen.Controls.Add(Me.btnvalidar)
        Me.grpResumen.Controls.Add(Me.lblestadoImport)
        Me.grpResumen.Controls.Add(Me.lblEliminados)
        Me.grpResumen.Controls.Add(Me.lblActualizados)
        Me.grpResumen.Controls.Add(Me.LblInsertadas)
        Me.grpResumen.Controls.Add(Me.lblFilasValidad)
        Me.grpResumen.Controls.Add(Me.lblFilasLeidas)
        Me.grpResumen.Location = New System.Drawing.Point(507, 33)
        Me.grpResumen.Name = "grpResumen"
        Me.grpResumen.Size = New System.Drawing.Size(388, 294)
        Me.grpResumen.TabIndex = 11
        Me.grpResumen.TabStop = False
        Me.grpResumen.Text = "Resumen"
        '
        'prgProgreso
        '
        Me.prgProgreso.Location = New System.Drawing.Point(22, 246)
        Me.prgProgreso.Name = "prgProgreso"
        Me.prgProgreso.Size = New System.Drawing.Size(331, 22)
        Me.prgProgreso.TabIndex = 10
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(247, 177)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(92, 27)
        Me.btnCerrar.TabIndex = 9
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'BtnRollBack
        '
        Me.BtnRollBack.Location = New System.Drawing.Point(247, 135)
        Me.BtnRollBack.Name = "BtnRollBack"
        Me.BtnRollBack.Size = New System.Drawing.Size(92, 27)
        Me.BtnRollBack.TabIndex = 8
        Me.BtnRollBack.Text = "Revertir"
        Me.BtnRollBack.UseVisualStyleBackColor = True
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(138, 135)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(92, 27)
        Me.btnProcesar.TabIndex = 7
        Me.btnProcesar.Text = "Procesar"
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'btnvalidar
        '
        Me.btnvalidar.Location = New System.Drawing.Point(30, 135)
        Me.btnvalidar.Name = "btnvalidar"
        Me.btnvalidar.Size = New System.Drawing.Size(92, 27)
        Me.btnvalidar.TabIndex = 6
        Me.btnvalidar.Text = "Validar"
        Me.btnvalidar.UseVisualStyleBackColor = True
        '
        'lblestadoImport
        '
        Me.lblestadoImport.AutoSize = True
        Me.lblestadoImport.Location = New System.Drawing.Point(198, 74)
        Me.lblestadoImport.Name = "lblestadoImport"
        Me.lblestadoImport.Size = New System.Drawing.Size(46, 13)
        Me.lblestadoImport.TabIndex = 5
        Me.lblestadoImport.Text = "Estado -"
        '
        'lblEliminados
        '
        Me.lblEliminados.AutoSize = True
        Me.lblEliminados.Location = New System.Drawing.Point(117, 74)
        Me.lblEliminados.Name = "lblEliminados"
        Me.lblEliminados.Size = New System.Drawing.Size(69, 13)
        Me.lblEliminados.TabIndex = 4
        Me.lblEliminados.Text = "Eliminados: 0"
        '
        'lblActualizados
        '
        Me.lblActualizados.AutoSize = True
        Me.lblActualizados.Location = New System.Drawing.Point(29, 74)
        Me.lblActualizados.Name = "lblActualizados"
        Me.lblActualizados.Size = New System.Drawing.Size(79, 13)
        Me.lblActualizados.TabIndex = 3
        Me.lblActualizados.Text = "Actualizados: 0"
        '
        'LblInsertadas
        '
        Me.LblInsertadas.AutoSize = True
        Me.LblInsertadas.Location = New System.Drawing.Point(198, 35)
        Me.LblInsertadas.Name = "LblInsertadas"
        Me.LblInsertadas.Size = New System.Drawing.Size(68, 13)
        Me.LblInsertadas.TabIndex = 2
        Me.LblInsertadas.Text = "Insertados: 0"
        '
        'lblFilasValidad
        '
        Me.lblFilasValidad.AutoSize = True
        Me.lblFilasValidad.Location = New System.Drawing.Point(133, 35)
        Me.lblFilasValidad.Name = "lblFilasValidad"
        Me.lblFilasValidad.Size = New System.Drawing.Size(53, 13)
        Me.lblFilasValidad.TabIndex = 1
        Me.lblFilasValidad.Text = "Validas: 0"
        '
        'lblFilasLeidas
        '
        Me.lblFilasLeidas.AutoSize = True
        Me.lblFilasLeidas.Location = New System.Drawing.Point(29, 35)
        Me.lblFilasLeidas.Name = "lblFilasLeidas"
        Me.lblFilasLeidas.Size = New System.Drawing.Size(50, 13)
        Me.lblFilasLeidas.TabIndex = 0
        Me.lblFilasLeidas.Text = "Leidas: 0"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssUsuario, Me.tssProveedor, Me.tssBatch, Me.tssImportId, Me.tssEstado})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 598)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(967, 22)
        Me.StatusStrip.TabIndex = 12
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'tssUsuario
        '
        Me.tssUsuario.Name = "tssUsuario"
        Me.tssUsuario.Size = New System.Drawing.Size(50, 17)
        Me.tssUsuario.Text = "Usuario:"
        '
        'tssProveedor
        '
        Me.tssProveedor.Name = "tssProveedor"
        Me.tssProveedor.Size = New System.Drawing.Size(64, 17)
        Me.tssProveedor.Text = "Proveedor:"
        '
        'tssBatch
        '
        Me.tssBatch.Name = "tssBatch"
        Me.tssBatch.Size = New System.Drawing.Size(50, 17)
        Me.tssBatch.Text = "Batch:--"
        '
        'tssImportId
        '
        Me.tssImportId.Name = "tssImportId"
        Me.tssImportId.Size = New System.Drawing.Size(53, 17)
        Me.tssImportId.Text = "ImportId"
        '
        'tssEstado
        '
        Me.tssEstado.Name = "tssEstado"
        Me.tssEstado.Size = New System.Drawing.Size(41, 17)
        Me.tssEstado.Text = "Listo : "
        '
        'FrmImportarProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(967, 620)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.grpResumen)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.lblProveedortip)
        Me.Controls.Add(Me.chkValidacionrapida)
        Me.Controls.Add(Me.chkReemplazoTotal)
        Me.Controls.Add(Me.grpOrigen)
        Me.Name = "FrmImportarProveedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccion Archivo Proveedor"
        Me.grpOrigen.ResumeLayout(False)
        Me.grpOrigen.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tabPreview.ResumeLayout(False)
        CType(Me.dgvPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabErrores.ResumeLayout(False)
        Me.tabErrores.PerformLayout()
        CType(Me.dvgErrores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tablog.ResumeLayout(False)
        Me.tablog.PerformLayout()
        Me.grpResumen.ResumeLayout(False)
        Me.grpResumen.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitulo As Label
    Friend WithEvents cmbProveedor As ComboBox
    Friend WithEvents BtnDescargarPlantilla As Button
    Friend WithEvents txtArchivo As TextBox
    Friend WithEvents BtnExaminar As Button
    Friend WithEvents lblArchivoInfo As Label
    Friend WithEvents grpOrigen As GroupBox
    Friend WithEvents chkReemplazoTotal As CheckBox
    Friend WithEvents chkValidacionrapida As CheckBox
    Friend WithEvents lblProveedortip As Label
    Friend WithEvents TabMain As TabControl
    Friend WithEvents tabPreview As TabPage
    Friend WithEvents dgvPreview As DataGridView
    Friend WithEvents tabErrores As TabPage
    Friend WithEvents dvgErrores As DataGridView
    Friend WithEvents lblErroresResumen As Label
    Friend WithEvents RowNum As DataGridViewTextBoxColumn
    Friend WithEvents Campo As DataGridViewTextBoxColumn
    Friend WithEvents MensajeError As DataGridViewTextBoxColumn
    Friend WithEvents tablog As TabPage
    Friend WithEvents txtlog As TextBox
    Friend WithEvents grpResumen As GroupBox
    Friend WithEvents lblFilasValidad As Label
    Friend WithEvents lblFilasLeidas As Label
    Friend WithEvents btnProcesar As Button
    Friend WithEvents btnvalidar As Button
    Friend WithEvents lblestadoImport As Label
    Friend WithEvents lblEliminados As Label
    Friend WithEvents lblActualizados As Label
    Friend WithEvents LblInsertadas As Label
    Friend WithEvents prgProgreso As ProgressBar
    Friend WithEvents btnCerrar As Button
    Friend WithEvents BtnRollBack As Button
    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents tssUsuario As ToolStripStatusLabel
    Friend WithEvents tssProveedor As ToolStripStatusLabel
    Friend WithEvents tssBatch As ToolStripStatusLabel
    Friend WithEvents tssImportId As ToolStripStatusLabel
    Friend WithEvents tssEstado As ToolStripStatusLabel
End Class
