VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form frmDetalhe_Pedido 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Pedido - Detalhe"
   ClientHeight    =   7095
   ClientLeft      =   1905
   ClientTop       =   1860
   ClientWidth     =   11745
   BeginProperty Font 
      Name            =   "Tahoma"
      Size            =   8.25
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   7095
   ScaleWidth      =   11745
   ShowInTaskbar   =   0   'False
   Begin VB.Frame fraCLIENTE 
      Caption         =   "Cliente"
      Height          =   680
      Left            =   2280
      TabIndex        =   14
      Top             =   240
      Width           =   8055
      Begin VB.TextBox txtCNPJ 
         ForeColor       =   &H80000002&
         Height          =   285
         Left            =   630
         Locked          =   -1  'True
         TabIndex        =   17
         Top             =   240
         Width           =   1770
      End
      Begin VB.TextBox txtRAZAO_SOCIAL 
         ForeColor       =   &H80000002&
         Height          =   285
         Left            =   2580
         Locked          =   -1  'True
         TabIndex        =   15
         Top             =   240
         Width           =   5010
      End
      Begin VB.Label lblLinha 
         AutoSize        =   -1  'True
         Caption         =   "-"
         Height          =   195
         Left            =   2460
         TabIndex        =   18
         Top             =   285
         Width           =   105
      End
      Begin VB.Label lblCNPJ 
         AutoSize        =   -1  'True
         Caption         =   "CNPJ : "
         Height          =   195
         Left            =   120
         TabIndex        =   16
         Top             =   285
         Width           =   525
      End
   End
   Begin MSComctlLib.ImageList ImgPretoBranco 
      Left            =   9840
      Top             =   1080
      _ExtentX        =   1005
      _ExtentY        =   1005
      BackColor       =   -2147483643
      ImageWidth      =   32
      ImageHeight     =   32
      MaskColor       =   12632256
      _Version        =   393216
      BeginProperty Images {2C247F25-8591-11D1-B16A-00C0F0283628} 
         NumListImages   =   8
         BeginProperty ListImage1 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmDetalhe_Pedido.frx":0000
            Key             =   "IMG1"
         EndProperty
         BeginProperty ListImage2 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmDetalhe_Pedido.frx":08DA
            Key             =   "IMG2"
         EndProperty
         BeginProperty ListImage3 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmDetalhe_Pedido.frx":11B4
            Key             =   "IMG3"
         EndProperty
         BeginProperty ListImage4 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmDetalhe_Pedido.frx":1A8E
            Key             =   "IMG4"
         EndProperty
         BeginProperty ListImage5 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmDetalhe_Pedido.frx":2368
            Key             =   "IMG5"
         EndProperty
         BeginProperty ListImage6 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmDetalhe_Pedido.frx":2C42
            Key             =   "IMG6"
         EndProperty
         BeginProperty ListImage7 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmDetalhe_Pedido.frx":351E
            Key             =   "IMG7"
         EndProperty
         BeginProperty ListImage8 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmDetalhe_Pedido.frx":3DFA
            Key             =   "IMG8"
         EndProperty
      EndProperty
   End
   Begin MSComctlLib.ImageList ImgColorido 
      Left            =   10560
      Top             =   1080
      _ExtentX        =   1005
      _ExtentY        =   1005
      BackColor       =   -2147483643
      ImageWidth      =   32
      ImageHeight     =   32
      MaskColor       =   12632256
      _Version        =   393216
      BeginProperty Images {2C247F25-8591-11D1-B16A-00C0F0283628} 
         NumListImages   =   8
         BeginProperty ListImage1 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmDetalhe_Pedido.frx":46D6
            Key             =   "Novo"
         EndProperty
         BeginProperty ListImage2 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmDetalhe_Pedido.frx":4FB0
            Key             =   "Propriedade"
         EndProperty
         BeginProperty ListImage3 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmDetalhe_Pedido.frx":588A
            Key             =   ""
         EndProperty
         BeginProperty ListImage4 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmDetalhe_Pedido.frx":6164
            Key             =   ""
         EndProperty
         BeginProperty ListImage5 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmDetalhe_Pedido.frx":6A3E
            Key             =   ""
         EndProperty
         BeginProperty ListImage6 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmDetalhe_Pedido.frx":7318
            Key             =   ""
         EndProperty
         BeginProperty ListImage7 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmDetalhe_Pedido.frx":7BF4
            Key             =   ""
         EndProperty
         BeginProperty ListImage8 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmDetalhe_Pedido.frx":84D0
            Key             =   ""
         EndProperty
      EndProperty
   End
   Begin VB.Frame fraDados 
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   7470
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   11700
      Begin VB.CommandButton cmdSair 
         Caption         =   "&Sair"
         Height          =   600
         Left            =   10440
         Style           =   1  'Graphical
         TabIndex        =   11
         Top             =   330
         Width           =   1095
      End
      Begin VB.Frame fraPEDIDO 
         Caption         =   "Pedido"
         Height          =   680
         Left            =   120
         TabIndex        =   2
         Top             =   240
         Width           =   2055
         Begin VB.TextBox txtNUM_PEDIDO 
            ForeColor       =   &H80000002&
            Height          =   285
            Left            =   825
            Locked          =   -1  'True
            TabIndex        =   12
            Top             =   240
            Width           =   1050
         End
         Begin VB.Label lblCODIGO 
            AutoSize        =   -1  'True
            Caption         =   "Número : "
            Height          =   195
            Left            =   120
            TabIndex        =   13
            Top             =   285
            Width           =   705
         End
      End
      Begin VB.Frame fraFUNDO1 
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   6120
         Left            =   120
         TabIndex        =   1
         Top             =   960
         Width           =   11490
         Begin VB.Frame fraNOTA_FISCAL 
            BeginProperty Font 
               Name            =   "Tahoma"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   5175
            Left            =   1380
            TabIndex        =   19
            Top             =   600
            Width           =   10995
            Begin VB.CommandButton cmdAtualizar_Nota_Fiscal 
               Caption         =   "&Atualizar"
               Height          =   315
               Left            =   9442
               TabIndex        =   40
               Top             =   250
               Width           =   870
            End
            Begin VB.CommandButton cmdDetalhar_Nota_Fiscal 
               Caption         =   "&Detalhar"
               Height          =   315
               Left            =   8490
               TabIndex        =   39
               Top             =   250
               Width           =   870
            End
            Begin VB.CommandButton cmdExcel_Nota_Fiscal 
               BeginProperty Font 
                  Name            =   "Tahoma"
                  Size            =   9.75
                  Charset         =   0
                  Weight          =   400
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Height          =   375
               Left            =   10395
               Picture         =   "frmDetalhe_Pedido.frx":8DAC
               Style           =   1  'Graphical
               TabIndex        =   23
               Top             =   220
               Width           =   495
            End
            Begin VB.CheckBox chkCARREGAR_NOTA_FISCAL_PEDIDO 
               Caption         =   "Carregar Automaticamente"
               Height          =   240
               Left            =   120
               TabIndex        =   22
               Top             =   240
               Value           =   1  'Checked
               Width           =   2775
            End
            Begin VB.Frame fra_lvwNota_Fical 
               Caption         =   "Listagem Geral"
               BeginProperty Font 
                  Name            =   "Tahoma"
                  Size            =   8.25
                  Charset         =   0
                  Weight          =   700
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Height          =   4395
               Left            =   120
               TabIndex        =   20
               Top             =   600
               Width           =   10770
               Begin MSComctlLib.ListView lvwNota_Fiscal_Pedido 
                  Height          =   4005
                  Left            =   135
                  TabIndex        =   21
                  Top             =   240
                  Width           =   10500
                  _ExtentX        =   18521
                  _ExtentY        =   7064
                  View            =   3
                  LabelWrap       =   -1  'True
                  HideSelection   =   -1  'True
                  AllowReorder    =   -1  'True
                  FullRowSelect   =   -1  'True
                  HotTracking     =   -1  'True
                  _Version        =   393217
                  ForeColor       =   -2147483640
                  BackColor       =   -2147483643
                  BorderStyle     =   1
                  Appearance      =   1
                  BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
                     Name            =   "Tahoma"
                     Size            =   8.25
                     Charset         =   0
                     Weight          =   400
                     Underline       =   0   'False
                     Italic          =   0   'False
                     Strikethrough   =   0   'False
                  EndProperty
                  NumItems        =   0
               End
            End
            Begin VB.Label lblTituloForm 
               AutoSize        =   -1  'True
               BackStyle       =   0  'Transparent
               Caption         =   "Nota Fiscal"
               BeginProperty Font 
                  Name            =   "Times New Roman"
                  Size            =   15.75
                  Charset         =   0
                  Weight          =   700
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               ForeColor       =   &H00FF8080&
               Height          =   360
               Index           =   6
               Left            =   4665
               TabIndex        =   24
               Top             =   210
               Width           =   1530
            End
            Begin VB.Label lblTituloForm 
               AutoSize        =   -1  'True
               BackStyle       =   0  'Transparent
               Caption         =   "Nota Fiscal"
               BeginProperty Font 
                  Name            =   "Times New Roman"
                  Size            =   15.75
                  Charset         =   0
                  Weight          =   700
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               ForeColor       =   &H00000000&
               Height          =   360
               Index           =   7
               Left            =   4680
               TabIndex        =   25
               Top             =   210
               Width           =   1530
            End
         End
         Begin VB.Frame fraPEDIDO_BLOQUEIOS 
            BeginProperty Font 
               Name            =   "Tahoma"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   5175
            Left            =   960
            TabIndex        =   26
            Top             =   600
            Width           =   10995
            Begin VB.CommandButton cmdAtualizar_Pedido_Bloqueios 
               Caption         =   "&Atualizar"
               Height          =   315
               Left            =   9442
               TabIndex        =   43
               Top             =   250
               Width           =   870
            End
            Begin VB.Frame fra_lvw_Pedido_Bloqueios 
               Caption         =   "Listagem Geral"
               BeginProperty Font 
                  Name            =   "Tahoma"
                  Size            =   8.25
                  Charset         =   0
                  Weight          =   700
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Height          =   4395
               Left            =   120
               TabIndex        =   29
               Top             =   600
               Width           =   10770
               Begin MSComctlLib.ListView lvwPedido_Bloqueios_Pedido 
                  Height          =   4005
                  Left            =   135
                  TabIndex        =   30
                  Top             =   240
                  Width           =   10500
                  _ExtentX        =   18521
                  _ExtentY        =   7064
                  View            =   3
                  LabelWrap       =   -1  'True
                  HideSelection   =   -1  'True
                  AllowReorder    =   -1  'True
                  FullRowSelect   =   -1  'True
                  HotTracking     =   -1  'True
                  _Version        =   393217
                  ForeColor       =   -2147483640
                  BackColor       =   -2147483643
                  BorderStyle     =   1
                  Appearance      =   1
                  BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
                     Name            =   "Tahoma"
                     Size            =   8.25
                     Charset         =   0
                     Weight          =   400
                     Underline       =   0   'False
                     Italic          =   0   'False
                     Strikethrough   =   0   'False
                  EndProperty
                  NumItems        =   0
               End
            End
            Begin VB.CheckBox chkCARREGAR_PEDIDO_BLOQUEIOS_PEDIDO 
               Caption         =   "Carregar Automaticamente"
               Height          =   240
               Left            =   120
               TabIndex        =   28
               Top             =   240
               Value           =   1  'Checked
               Width           =   2775
            End
            Begin VB.CommandButton cmdExcel_Pedido_Bloqueios 
               BeginProperty Font 
                  Name            =   "Tahoma"
                  Size            =   9.75
                  Charset         =   0
                  Weight          =   400
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Height          =   375
               Left            =   10395
               Picture         =   "frmDetalhe_Pedido.frx":9132
               Style           =   1  'Graphical
               TabIndex        =   27
               Top             =   220
               Width           =   495
            End
            Begin VB.Label lblTituloForm 
               AutoSize        =   -1  'True
               BackStyle       =   0  'Transparent
               Caption         =   "Pedido Bloqueios"
               BeginProperty Font 
                  Name            =   "Times New Roman"
                  Size            =   15.75
                  Charset         =   0
                  Weight          =   700
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               ForeColor       =   &H00FF8080&
               Height          =   360
               Index           =   4
               Left            =   4665
               TabIndex        =   31
               Top             =   210
               Width           =   2310
            End
            Begin VB.Label lblTituloForm 
               AutoSize        =   -1  'True
               BackStyle       =   0  'Transparent
               Caption         =   "Pedido Bloqueios"
               BeginProperty Font 
                  Name            =   "Times New Roman"
                  Size            =   15.75
                  Charset         =   0
                  Weight          =   700
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               ForeColor       =   &H00000000&
               Height          =   360
               Index           =   5
               Left            =   4680
               TabIndex        =   32
               Top             =   210
               Width           =   2310
            End
         End
         Begin VB.Frame fraOBSERVACAO_PEDIDO 
            BeginProperty Font 
               Name            =   "Tahoma"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   5175
            Left            =   570
            TabIndex        =   33
            Top             =   600
            Width           =   10995
            Begin VB.CommandButton cmdAtualizar_Observacao_Pedido 
               Caption         =   "&Atualizar"
               Height          =   315
               Left            =   9442
               TabIndex        =   42
               Top             =   250
               Width           =   870
            End
            Begin VB.CommandButton cmdExcel_Observacao_Pedido 
               BeginProperty Font 
                  Name            =   "Tahoma"
                  Size            =   9.75
                  Charset         =   0
                  Weight          =   400
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Height          =   375
               Left            =   10395
               Picture         =   "frmDetalhe_Pedido.frx":94B8
               Style           =   1  'Graphical
               TabIndex        =   41
               Top             =   220
               Width           =   495
            End
            Begin VB.CheckBox chkCARREGAR_OBSERVACAO_PEDIDO_PEDIDO 
               Caption         =   "Carregar Automaticamente"
               Height          =   240
               Left            =   120
               TabIndex        =   36
               Top             =   240
               Value           =   1  'Checked
               Width           =   2775
            End
            Begin VB.Frame fra_lvwObservacao_Pedido 
               Caption         =   "Listagem Geral"
               BeginProperty Font 
                  Name            =   "Tahoma"
                  Size            =   8.25
                  Charset         =   0
                  Weight          =   700
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Height          =   4395
               Left            =   120
               TabIndex        =   34
               Top             =   600
               Width           =   10770
               Begin MSComctlLib.ListView lvwObservacao_Pedido_Pedido 
                  Height          =   4005
                  Left            =   135
                  TabIndex        =   35
                  Top             =   240
                  Width           =   10500
                  _ExtentX        =   18521
                  _ExtentY        =   7064
                  View            =   3
                  LabelWrap       =   -1  'True
                  HideSelection   =   -1  'True
                  AllowReorder    =   -1  'True
                  FullRowSelect   =   -1  'True
                  HotTracking     =   -1  'True
                  _Version        =   393217
                  ForeColor       =   -2147483640
                  BackColor       =   -2147483643
                  BorderStyle     =   1
                  Appearance      =   1
                  BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
                     Name            =   "Tahoma"
                     Size            =   8.25
                     Charset         =   0
                     Weight          =   400
                     Underline       =   0   'False
                     Italic          =   0   'False
                     Strikethrough   =   0   'False
                  EndProperty
                  NumItems        =   0
               End
            End
            Begin VB.Label lblTituloForm 
               AutoSize        =   -1  'True
               BackStyle       =   0  'Transparent
               Caption         =   "Observação Pedido"
               BeginProperty Font 
                  Name            =   "Times New Roman"
                  Size            =   15.75
                  Charset         =   0
                  Weight          =   700
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               ForeColor       =   &H00FF8080&
               Height          =   360
               Index           =   2
               Left            =   4665
               TabIndex        =   37
               Top             =   210
               Width           =   2610
            End
            Begin VB.Label lblTituloForm 
               AutoSize        =   -1  'True
               BackStyle       =   0  'Transparent
               Caption         =   "Observação Pedido"
               BeginProperty Font 
                  Name            =   "Times New Roman"
                  Size            =   15.75
                  Charset         =   0
                  Weight          =   700
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               ForeColor       =   &H00000000&
               Height          =   360
               Index           =   3
               Left            =   4680
               TabIndex        =   38
               Top             =   210
               Width           =   2610
            End
         End
         Begin VB.Frame fraITENS_PEDIDO 
            BeginProperty Font 
               Name            =   "Tahoma"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   5175
            Left            =   240
            TabIndex        =   4
            Top             =   600
            Width           =   10995
            Begin VB.CommandButton cmdAtualizar_Itens_Pedido 
               Caption         =   "&Atualizar"
               Height          =   315
               Left            =   9442
               TabIndex        =   44
               Top             =   250
               Width           =   870
            End
            Begin VB.CommandButton cmdExcel_Itens_Pedido 
               BeginProperty Font 
                  Name            =   "Tahoma"
                  Size            =   9.75
                  Charset         =   0
                  Weight          =   400
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Height          =   375
               Left            =   10395
               Picture         =   "frmDetalhe_Pedido.frx":983E
               Style           =   1  'Graphical
               TabIndex        =   10
               Top             =   220
               Width           =   495
            End
            Begin VB.CheckBox chkCARREGAR_ITENS_PEDIDO_PEDIDO 
               Caption         =   "Carregar Automaticamente"
               Height          =   240
               Left            =   120
               TabIndex        =   9
               Top             =   240
               Value           =   1  'Checked
               Width           =   2775
            End
            Begin VB.Frame fra_lvwItens_Pedido 
               Caption         =   "Listagem Geral"
               BeginProperty Font 
                  Name            =   "Tahoma"
                  Size            =   8.25
                  Charset         =   0
                  Weight          =   700
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Height          =   4395
               Left            =   120
               TabIndex        =   5
               Top             =   600
               Width           =   10770
               Begin MSComctlLib.ListView lvwItens_Pedido_Pedido 
                  Height          =   4005
                  Left            =   135
                  TabIndex        =   6
                  Top             =   240
                  Width           =   10500
                  _ExtentX        =   18521
                  _ExtentY        =   7064
                  View            =   3
                  LabelWrap       =   -1  'True
                  HideSelection   =   -1  'True
                  AllowReorder    =   -1  'True
                  FullRowSelect   =   -1  'True
                  HotTracking     =   -1  'True
                  _Version        =   393217
                  ForeColor       =   -2147483640
                  BackColor       =   -2147483643
                  BorderStyle     =   1
                  Appearance      =   1
                  BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
                     Name            =   "Tahoma"
                     Size            =   8.25
                     Charset         =   0
                     Weight          =   400
                     Underline       =   0   'False
                     Italic          =   0   'False
                     Strikethrough   =   0   'False
                  EndProperty
                  NumItems        =   0
               End
            End
            Begin VB.Label lblTituloForm 
               AutoSize        =   -1  'True
               BackStyle       =   0  'Transparent
               Caption         =   "Itens Pedido"
               BeginProperty Font 
                  Name            =   "Times New Roman"
                  Size            =   15.75
                  Charset         =   0
                  Weight          =   700
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               ForeColor       =   &H00FF8080&
               Height          =   360
               Index           =   0
               Left            =   4665
               TabIndex        =   7
               Top             =   210
               Width           =   1650
            End
            Begin VB.Label lblTituloForm 
               AutoSize        =   -1  'True
               BackStyle       =   0  'Transparent
               Caption         =   "Itens Pedido"
               BeginProperty Font 
                  Name            =   "Times New Roman"
                  Size            =   15.75
                  Charset         =   0
                  Weight          =   700
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               ForeColor       =   &H00000000&
               Height          =   360
               Index           =   1
               Left            =   4680
               TabIndex        =   8
               Top             =   210
               Width           =   1650
            End
         End
         Begin MSComctlLib.TabStrip tabDetalhe 
            Height          =   5775
            Left            =   120
            TabIndex        =   3
            Top             =   240
            Width           =   11220
            _ExtentX        =   19791
            _ExtentY        =   10186
            _Version        =   393216
            BeginProperty Tabs {1EFB6598-857C-11D1-B16A-00C0F0283628} 
               NumTabs         =   4
               BeginProperty Tab1 {1EFB659A-857C-11D1-B16A-00C0F0283628} 
                  Caption         =   "&Itens"
                  Key             =   "Itens_Pedido"
                  ImageVarType    =   2
               EndProperty
               BeginProperty Tab2 {1EFB659A-857C-11D1-B16A-00C0F0283628} 
                  Caption         =   "&Observação"
                  Key             =   "Observacao_Pedido"
                  ImageVarType    =   2
               EndProperty
               BeginProperty Tab3 {1EFB659A-857C-11D1-B16A-00C0F0283628} 
                  Caption         =   "&Pedido Bloqueios"
                  Key             =   "Pedido_Bloqueios"
                  ImageVarType    =   2
               EndProperty
               BeginProperty Tab4 {1EFB659A-857C-11D1-B16A-00C0F0283628} 
                  Caption         =   "&Nota Fiscal"
                  Key             =   "Nota_Fiscal"
                  ImageVarType    =   2
               EndProperty
            EndProperty
            BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
               Name            =   "Tahoma"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
         End
      End
   End
End
Attribute VB_Name = "frmDetalhe_Pedido"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private gstrCod              As String
Private gstrCNPJ             As String
Private gstrRAZAO_SOCIAL     As String
Public Property Get Codigo() As String
   Codigo = gstrCod
End Property

Public Property Let Codigo(pCOD As String)
   gstrCod = pCOD
End Property

Public Property Get CNPJ() As String
   CNPJ = gstrCNPJ
End Property

Public Property Let CNPJ(pCNPJ As String)
   gstrCNPJ = pCNPJ
End Property
Public Property Get RAZAO_SOCIAL() As String
   RAZAO_SOCIAL = gstrRAZAO_SOCIAL
End Property

Public Property Let RAZAO_SOCIAL(pRAZAO_SOCIAL As String)
   gstrRAZAO_SOCIAL = pRAZAO_SOCIAL
End Property

Private Sub cmdAtualizar_Itens_Pedido_Click()
    Atualiza_Lista_Itens_Pedido
End Sub

Private Sub cmdAtualizar_Nota_Fiscal_Click()
    Atualiza_Lista_Nota_Fiscal
End Sub

Private Sub cmdAtualizar_Observacao_Pedido_Click()
    Atualiza_Lista_Observacao_Pedido
End Sub

Private Sub cmdAtualizar_Pedido_Bloqueios_Click()
    Atualiza_Lista_Pedido_Bloqueios
End Sub

Private Sub cmdDetalhar_Nota_Fiscal_Click()
     lvwNota_Fiscal_Pedido_DblClick
End Sub

Private Sub cmdExcel_Itens_Pedido_Click()
    GerarExcel_ListView lvwItens_Pedido_Pedido
End Sub

Private Sub cmdExcel_Observacao_Pedido_Click()
    GerarExcel_ListView lvwObservacao_Pedido_Pedido
End Sub

Private Sub cmdExcel_Pedido_Bloqueios_Click()
    GerarExcel_ListView lvwPedido_Bloqueios_Pedido
End Sub
Private Sub cmdExcel_Nota_Fiscal_Click()
    GerarExcel_ListView lvwNota_Fiscal_Pedido
End Sub

Private Sub cmdSair_Click()
    Unload Me
End Sub

Private Sub Form_Load()
   
   Screen.MousePointer = vbHourglass
   
   PreparaForm Me
      
   Centra_Form Me, False
   
   RetornaCheckbox chkCARREGAR_ITENS_PEDIDO_PEDIDO
   RetornaCheckbox chkCARREGAR_OBSERVACAO_PEDIDO_PEDIDO
   RetornaCheckbox chkCARREGAR_PEDIDO_BLOQUEIOS_PEDIDO
   RetornaCheckbox chkCARREGAR_NOTA_FISCAL_PEDIDO
   
   Atualiza_Controles
   
   tabDetalhe_Click
   
   Screen.MousePointer = vbDefault
   
End Sub

Private Sub Atualiza_Controles()
   
   '---- Itens
   If chkCARREGAR_ITENS_PEDIDO_PEDIDO.Value = vbChecked Then
        Atualiza_Lista_Itens_Pedido
   End If
   
   If chkCARREGAR_OBSERVACAO_PEDIDO_PEDIDO.Value = vbChecked Then
        Atualiza_Lista_Observacao_Pedido
   End If
   
   If chkCARREGAR_PEDIDO_BLOQUEIOS_PEDIDO.Value = vbChecked Then
        Atualiza_Lista_Pedido_Bloqueios
   End If
      
   If chkCARREGAR_NOTA_FISCAL_PEDIDO.Value = vbChecked Then
        Atualiza_Lista_Nota_Fiscal
   End If
   
   txtNUM_PEDIDO.Text = gstrCod
   txtCNPJ.Text = gstrCNPJ
   txtRAZAO_SOCIAL.Text = gstrRAZAO_SOCIAL
   
   
End Sub


Private Sub Form_Unload(Cancel As Integer)
   
   Set frmDetalhe_Pedido = Nothing
         
   GravaPosicaoList lvwItens_Pedido_Pedido
   GravaPosicaoList lvwObservacao_Pedido_Pedido
   GravaPosicaoList lvwPedido_Bloqueios_Pedido
   GravaPosicaoList lvwNota_Fiscal_Pedido
   
      
   FechaLista lvwItens_Pedido_Pedido
   FechaLista lvwObservacao_Pedido_Pedido
   FechaLista lvwPedido_Bloqueios_Pedido
   FechaLista lvwNota_Fiscal_Pedido
         
   GravaCheckbox chkCARREGAR_ITENS_PEDIDO_PEDIDO
   GravaCheckbox chkCARREGAR_OBSERVACAO_PEDIDO_PEDIDO
   GravaCheckbox chkCARREGAR_PEDIDO_BLOQUEIOS_PEDIDO
   GravaCheckbox chkCARREGAR_NOTA_FISCAL_PEDIDO
   
   FechaForm Me
   
End Sub

Private Sub lvwItens_Pedido_Pedido_ColumnClick(ByVal ColumnHeader As MSComctlLib.ColumnHeader)

   Dim intColuna As Integer
   
   intColuna = ColumnHeader.Index - 1
   
   Select Case intColuna
   
        Case 14
            intColuna = 16
        Case 15
            intColuna = 17
            
   End Select
        
   If lvwItens_Pedido_Pedido.SortKey = intColuna Then

       If lvwItens_Pedido_Pedido.SortOrder = lvwAscending Then
           lvwItens_Pedido_Pedido.SortOrder = lvwDescending
       Else
           lvwItens_Pedido_Pedido.SortOrder = lvwAscending
       End If

   Else

       lvwItens_Pedido_Pedido.SortKey = intColuna
       lvwItens_Pedido_Pedido.SortOrder = lvwAscending

   End If

   lvwItens_Pedido_Pedido.Sorted = True

End Sub

Private Sub lvwNota_Fiscal_Pedido_DblClick()
    
    On Error GoTo TrataErro
    
    If lvwNota_Fiscal_Pedido.ListItems.Count = 0 Then Exit Sub
    With frmDetalhe_Nota_Fiscal
        .Codigo = gstrCod
        .CNPJ = gstrCNPJ
        .RAZAO_SOCIAL = gstrRAZAO_SOCIAL
        .COD_NOTA_FISCAL = lvwNota_Fiscal_Pedido.SelectedItem.Text
        .SERIE = lvwNota_Fiscal_Pedido.SelectedItem.SubItems(1)
        .Show 1
    End With

    Exit Sub

TrataErro:

    Unload Me

End Sub

Private Sub lvwObservacao_Pedido_Pedido_ColumnClick(ByVal ColumnHeader As MSComctlLib.ColumnHeader)

   If lvwObservacao_Pedido_Pedido.SortKey = ColumnHeader.Index - 1 Then

       If lvwObservacao_Pedido_Pedido.SortOrder = lvwAscending Then
           lvwObservacao_Pedido_Pedido.SortOrder = lvwDescending
       Else
           lvwObservacao_Pedido_Pedido.SortOrder = lvwAscending
       End If

   Else

       lvwObservacao_Pedido_Pedido.SortKey = ColumnHeader.Index - 1
       lvwObservacao_Pedido_Pedido.SortOrder = lvwAscending

   End If

   lvwObservacao_Pedido_Pedido.Sorted = True

End Sub

Private Sub lvwPedido_Bloqueios_Pedido_ColumnClick(ByVal ColumnHeader As MSComctlLib.ColumnHeader)

   Dim intColuna As Integer
   
   intColuna = ColumnHeader.Index - 1
   
   Select Case intColuna
   
        Case 3
            intColuna = 6
                   
   End Select
        
   If lvwPedido_Bloqueios_Pedido.SortKey = intColuna Then

       If lvwPedido_Bloqueios_Pedido.SortOrder = lvwAscending Then
           lvwPedido_Bloqueios_Pedido.SortOrder = lvwDescending
       Else
           lvwPedido_Bloqueios_Pedido.SortOrder = lvwAscending
       End If

   Else

       lvwPedido_Bloqueios_Pedido.SortKey = intColuna
       lvwPedido_Bloqueios_Pedido.SortOrder = lvwAscending

   End If

   lvwPedido_Bloqueios_Pedido.Sorted = True

End Sub


Private Sub lvwNota_Fiscal_Pedido_ColumnClick(ByVal ColumnHeader As MSComctlLib.ColumnHeader)

   Dim intColuna As Integer
   
   intColuna = ColumnHeader.Index - 1
   
   Select Case intColuna
   
        Case 6
            intColuna = 23
        Case 7
            intColuna = 24
            
   End Select
        
   If lvwNota_Fiscal_Pedido.SortKey = intColuna Then

       If lvwNota_Fiscal_Pedido.SortOrder = lvwAscending Then
           lvwNota_Fiscal_Pedido.SortOrder = lvwDescending
       Else
           lvwNota_Fiscal_Pedido.SortOrder = lvwAscending
       End If

   Else

       lvwNota_Fiscal_Pedido.SortKey = intColuna
       lvwNota_Fiscal_Pedido.SortOrder = lvwAscending

   End If

   lvwNota_Fiscal_Pedido.Sorted = True

End Sub

Private Sub tabDetalhe_Click()

    
    fraITENS_PEDIDO.Visible = False
    fraOBSERVACAO_PEDIDO.Visible = False
    fraPEDIDO_BLOQUEIOS.Visible = False
    fraNOTA_FISCAL.Visible = False
        
    fraOBSERVACAO_PEDIDO.Left = fraITENS_PEDIDO.Left
    fraPEDIDO_BLOQUEIOS.Left = fraITENS_PEDIDO.Left
    fraNOTA_FISCAL.Left = fraITENS_PEDIDO.Left
    
    Select Case UCase(tabDetalhe.SelectedItem.Key)
        
        Case "ITENS_PEDIDO"
            fraITENS_PEDIDO.Visible = True
            
        Case "OBSERVACAO_PEDIDO"
            fraOBSERVACAO_PEDIDO.Visible = True
                    
        Case "PEDIDO_BLOQUEIOS"
            fraPEDIDO_BLOQUEIOS.Visible = True
        
        Case "NOTA_FISCAL"
            fraNOTA_FISCAL.Visible = True
              
    End Select
    
End Sub

Private Sub Atualiza_Lista_Itens_Pedido()
   
   On Error GoTo ValidaErro
   Me.MousePointer = vbHourglass
   
    Dim Rst As adodb.Recordset
   
    Dim itmX As ListItem
   
    
    Dim fldNUM_PEDIDO
    Dim fldCOD_PRODUTO
    Dim fldID_SEQUENCIAL
    Dim fldQTD_PEDIDA
    Dim fldQTD_FATURADA
    Dim fldQTD_DESTINADA
    Dim fldQTD_EMPENHADA
    Dim fldSITUACAO
    Dim fldVLR_PRECO
    Dim fldVLR_SALDO
    Dim fldVLR_UNITARIO
    Dim fldDESCONTO
    Dim fldCOND_PAGTO
    Dim fldTAB_PRECO
    Dim fldDES_PRODUTO_CURTA
    Dim fldDES_PRODUTO_LONGA
    Dim fldDATA_CEDO
    Dim fldDATA_TARDE
    Dim fldDATA_BASE
    Dim fldGRP_FISC_PRC
    Dim fldOPER_FISC_PRC
    Dim fldGRP_FISC_ENT
    Dim fldOPER_FISC_ENT
    
    Dim strORDENA_DATA As String
    
    Set Rst = New adodb.Recordset
      
    lvwItens_Pedido_Pedido.ListItems.Clear
        
    Set Rst = Listar_Itens_Pedido(gstrCod)
   
    Set fldNUM_PEDIDO = Rst.Fields("NUM_PEDIDO")
    Set fldCOD_PRODUTO = Rst.Fields("COD_PRODUTO")
    Set fldID_SEQUENCIAL = Rst.Fields("ID_SEQUENCIAL")
    Set fldQTD_PEDIDA = Rst.Fields("QTD_PEDIDA")
    Set fldQTD_FATURADA = Rst.Fields("QTD_FATURADA")
    Set fldQTD_DESTINADA = Rst.Fields("QTD_DESTINADA")
    Set fldQTD_EMPENHADA = Rst.Fields("QTD_EMPENHADA")
    Set fldSITUACAO = Rst.Fields("SITUACAO")
    Set fldVLR_PRECO = Rst.Fields("VLR_PRECO")
    Set fldVLR_SALDO = Rst.Fields("VLR_SALDO")
    Set fldVLR_UNITARIO = Rst.Fields("VLR_UNITARIO")
    Set fldDESCONTO = Rst.Fields("DESCONTO")
    Set fldCOND_PAGTO = Rst.Fields("COND_PAGTO")
    Set fldTAB_PRECO = Rst.Fields("TABELA_PRECO")
    Set fldDES_PRODUTO_CURTA = Rst.Fields("DES_PRODUTO_CURTA")
    Set fldDES_PRODUTO_LONGA = Rst.Fields("DES_PRODUTO_LONGA")
    Set fldDATA_CEDO = Rst.Fields("DATA_CEDO")
    Set fldDATA_TARDE = Rst.Fields("DATA_TARDE")
    Set fldDATA_BASE = Rst.Fields("DATA_BASE")
    Set fldGRP_FISC_PRC = Rst.Fields("GRP_FISCAL_PRC")
    Set fldOPER_FISC_PRC = Rst.Fields("OPER_FISCAL_PRC")
    Set fldGRP_FISC_ENT = Rst.Fields("GRP_FISCAL_ENT")
    Set fldOPER_FISC_ENT = Rst.Fields("OPER_FISCAL_ENT")
          
    If Rst.EOF Then
   
      With Me.lvwItens_Pedido_Pedido
          .ColumnHeaders.Clear
          .ListItems.Clear
          .ColumnHeaders.Add , , "Mensagem : Não existem registros selecionados.", 9000
      End With
   
    Else
   
      With lvwItens_Pedido_Pedido
          .ListItems.Clear
          With .ColumnHeaders
            .Clear
            .Add , , "Seq.", 500
            .Add , , "Cód.Prod. Cliente", 500
            .Add , , "Descr. Curta Prod.", 500
            .Add , , "Descr. Longa Prod.", 500
            .Add , , "Qtde Pedida", 500, vbRightJustify
            .Add , , "Qtde Faturada", 500, vbRightJustify
            .Add , , "Qtde Destinada", 500, vbRightJustify
            .Add , , "Qtde Empenhada", 500, vbRightJustify
            .Add , , "Situação", 500, vbRightJustify
            .Add , , "Preço", 500, vbRightJustify
            .Add , , "Saldo", 500, vbRightJustify
            .Add , , "Unitário", 500, vbRightJustify
            .Add , , "Desconto", 500, vbRightJustify
            .Add , , "Condição Pagamento.", 1000
            .Add , , "Tabela Preço", 500
            .Add , , "Data Base", 500
            .Add , , "Data Cedo", 500
            .Add , , "Data Tarde", 500
            .Add , , "Grupo Op.Fiscal", 500
            .Add , , "Oper. Fiscal", 500
            .Add , , "Grp Op.Fiscal Entrega", 500
            .Add , , "Oper. Fiscal Entrega", 500
            .Add , , "Data Cedo", 500
            .Add , , "Data Tarde", 500
         
         End With
      End With
      
      PreparaLista lvwItens_Pedido_Pedido
     
      With Rst.Fields
         
         Rst.MoveFirst
      
         Do While Not Rst.EOF
     
         
            Set itmX = lvwItens_Pedido_Pedido.ListItems.Add(, , fldID_SEQUENCIAL)
            
            itmX.SubItems(1) = IIf(Not Vazio(fldCOD_PRODUTO), fldCOD_PRODUTO, "")
            itmX.SubItems(2) = IIf(Not Vazio(fldDES_PRODUTO_CURTA), fldDES_PRODUTO_CURTA, "")
            itmX.SubItems(3) = IIf(Not Vazio(fldDES_PRODUTO_LONGA), fldDES_PRODUTO_LONGA, "")
            itmX.SubItems(4) = IIf(Not Vazio(Trim(fldQTD_PEDIDA)), ObterCampoNumerico(fldQTD_PEDIDA), "0")
            itmX.SubItems(5) = IIf(Not Vazio(Trim(fldQTD_FATURADA)), ObterCampoNumerico(fldQTD_FATURADA), "0")
            itmX.SubItems(6) = IIf(Not Vazio(Trim(fldQTD_DESTINADA)), ObterCampoNumerico(fldQTD_DESTINADA), "0")
            itmX.SubItems(7) = IIf(Not Vazio(Trim(fldQTD_EMPENHADA)), ObterCampoNumerico(fldQTD_EMPENHADA), "0")
            itmX.SubItems(8) = IIf(Not Vazio(Trim(fldSITUACAO)), fldSITUACAO, "")
            itmX.SubItems(9) = IIf(Not Vazio(Trim(fldVLR_PRECO)), ObterCampoNumerico(fldVLR_PRECO), "0")
            itmX.SubItems(10) = IIf(Not Vazio(Trim(fldVLR_SALDO)), ObterCampoNumerico(fldVLR_SALDO), "0")
            itmX.SubItems(11) = IIf(Not Vazio(Trim(fldVLR_UNITARIO)), ObterCampoNumerico(fldVLR_UNITARIO), "0")
            itmX.SubItems(12) = IIf(Not Vazio(Trim(fldDESCONTO)), ObterCampoNumerico(fldDESCONTO), "0")
            itmX.SubItems(13) = IIf(Not Vazio(Trim(fldCOND_PAGTO)), fldCOND_PAGTO, "")
            itmX.SubItems(14) = IIf(Not Vazio(Trim(fldTAB_PRECO)), fldTAB_PRECO, "")
            itmX.SubItems(15) = IIf(Not Vazio(Trim(fldDATA_BASE)), fldDATA_BASE, "")
            itmX.SubItems(16) = IIf(Not Vazio(Trim(fldDATA_CEDO)), fldDATA_CEDO, "")
            itmX.SubItems(17) = IIf(Not Vazio(Trim(fldDATA_TARDE)), fldDATA_TARDE, "")
            itmX.SubItems(18) = IIf(Not Vazio(fldGRP_FISC_PRC), fldGRP_FISC_PRC, "")
            itmX.SubItems(19) = IIf(Not Vazio(fldOPER_FISC_PRC), fldOPER_FISC_PRC, "")
            itmX.SubItems(20) = IIf(Not Vazio(fldGRP_FISC_ENT), fldGRP_FISC_ENT, "")
            itmX.SubItems(21) = IIf(Not Vazio(fldOPER_FISC_ENT), fldOPER_FISC_ENT, "")
                                                            
            If Not Vazio(fldDATA_CEDO) Then
                strORDENA_DATA = Right(fldDATA_CEDO, 4) & Mid(fldDATA_CEDO, 4, 2) & Left(fldDATA_CEDO, 2)
                itmX.SubItems(22) = strORDENA_DATA
            Else
                strORDENA_DATA = ""
                itmX.SubItems(22) = strORDENA_DATA
            End If
            
            If Not Vazio(fldDATA_TARDE) Then
                strORDENA_DATA = Right(fldDATA_TARDE, 4) & Mid(fldDATA_TARDE, 4, 2) & Left(fldDATA_TARDE, 2)
                itmX.SubItems(23) = strORDENA_DATA
            Else
                strORDENA_DATA = ""
                itmX.SubItems(23) = strORDENA_DATA
            End If
                                                            
            Rst.MoveNext
         Loop
      
      End With
      
      lvwItens_Pedido_Pedido.ColumnHeaders.Item(23).Width = 0
      lvwItens_Pedido_Pedido.ColumnHeaders.Item(24).Width = 0
   
    End If
   
    Dim intPosicao As Double
    
    intPosicao = RetornaPosicaoList(lvwItens_Pedido_Pedido)
   
    If intPosicao <> 0 Then
    
       lvwItens_Pedido_Pedido.ListItems.Item(intPosicao).Selected = True
    
    End If
   
    Set Rst = Nothing
   
    Me.MousePointer = vbDefault
   
    Exit Sub
ValidaErro:
   
   Me.MousePointer = vbDefault
   TrataErro Err.Number, Err.Description, Err.Source, True, Me.Caption
   
End Sub


Private Sub Atualiza_Lista_Observacao_Pedido()
   
   On Error GoTo ValidaErro
   Me.MousePointer = vbHourglass
   
   Dim Rst As adodb.Recordset
   
   Dim itmX As ListItem
      
   Dim fldNUM_PEDIDO
   Dim fldID_SEQUENCIAL
   Dim fldDES_TIPO_OPERACAO
   Dim fldINSCRICAO_ESTADUAL
   Dim fldNOME
   Dim fldENDERECO
   Dim fldMRH
   Dim fldCIDADE
   Dim fldUF
   Dim fldMUNICIPIO
   Dim fldTEXTO_NOTA_FISCAL
   Dim fldTEXTO_LIVRE
    
   Set Rst = New adodb.Recordset
      
   lvwObservacao_Pedido_Pedido.ListItems.Clear
        
   Set Rst = Listar_Observacao_Pedido(gstrCod)
   
   Set fldNUM_PEDIDO = Rst.Fields("NUM_PEDIDO")
   Set fldID_SEQUENCIAL = Rst.Fields("ID_SEQUENCIAL")
   Set fldDES_TIPO_OPERACAO = Rst.Fields("DES_TIPO_OPERACAO")
   Set fldINSCRICAO_ESTADUAL = Rst.Fields("INSCRICAO_ESTADUAL")
   Set fldNOME = Rst.Fields("NOME")
   Set fldENDERECO = Rst.Fields("ENDERECO")
   Set fldMRH = Rst.Fields("MRH")
   Set fldCIDADE = Rst.Fields("CIDADE")
   Set fldUF = Rst.Fields("UF")
   Set fldMUNICIPIO = Rst.Fields("MUNICIPIO")
   Set fldTEXTO_NOTA_FISCAL = Rst.Fields("TEXTO_NOTA_FISCAL")
   Set fldTEXTO_LIVRE = Rst.Fields("TEXTO_LIVRE")
          
   If Rst.EOF Then
   
      With Me.lvwObservacao_Pedido_Pedido
          .ColumnHeaders.Clear
          .ListItems.Clear
          .ColumnHeaders.Add , , "Mensagem : Não existem registros selecionados.", 9000
      End With
   
   Else
   
      With lvwObservacao_Pedido_Pedido
          .ListItems.Clear
          With .ColumnHeaders
            .Clear
            .Add , , "Seq.", 500
            .Add , , "Tipo Operação", 500
            .Add , , "Inscrição Estadual Cliente", 500
            .Add , , "Nome", 500
            .Add , , "Endereço", 500
            .Add , , "Cidade", 500
            .Add , , "UF", 500
            .Add , , "Município", 500
            .Add , , "MRH", 500
            .Add , , "Texto Nota Fiscal", 500
            .Add , , "Texto Livre", 500
         End With
      End With
      
      PreparaLista lvwObservacao_Pedido_Pedido
     
      With Rst.Fields
         
         Rst.MoveFirst
      
         Do While Not Rst.EOF
     
            Set itmX = lvwObservacao_Pedido_Pedido.ListItems.Add(, , fldID_SEQUENCIAL)
         
            itmX.SubItems(1) = IIf(Not Vazio(fldDES_TIPO_OPERACAO), fldDES_TIPO_OPERACAO, "")
            itmX.SubItems(2) = IIf(Not Vazio(fldINSCRICAO_ESTADUAL), fldINSCRICAO_ESTADUAL, "")
            itmX.SubItems(3) = IIf(Not Vazio(fldNOME), fldNOME, "")
            itmX.SubItems(4) = IIf(Not Vazio(fldENDERECO), fldENDERECO, "")
            itmX.SubItems(5) = IIf(Not Vazio(fldCIDADE), fldCIDADE, "")
            itmX.SubItems(6) = IIf(Not Vazio(fldUF), fldUF, "")
            itmX.SubItems(7) = IIf(Not Vazio(fldMUNICIPIO), fldMUNICIPIO, "")
            itmX.SubItems(8) = IIf(Not Vazio(fldMRH), fldMRH, "")
            itmX.SubItems(9) = IIf(Not Vazio(fldTEXTO_NOTA_FISCAL), fldTEXTO_NOTA_FISCAL, "")
            itmX.SubItems(10) = IIf(Not Vazio(fldTEXTO_LIVRE), fldTEXTO_LIVRE, "")
                                             
            Rst.MoveNext
         Loop
      
      End With
   
   End If
   
   Dim intPosicao As Double
    
   intPosicao = RetornaPosicaoList(lvwObservacao_Pedido_Pedido)
   
   If intPosicao <> 0 Then
    
       lvwObservacao_Pedido_Pedido.ListItems.Item(intPosicao).Selected = True
    
   End If
   
   Set Rst = Nothing
   
   Me.MousePointer = vbDefault
   
   Exit Sub
ValidaErro:
   
   Me.MousePointer = vbDefault
   TrataErro Err.Number, Err.Description, Err.Source, True, Me.Caption
   
End Sub



Private Sub Atualiza_Lista_Pedido_Bloqueios()
   
   On Error GoTo ValidaErro
   Me.MousePointer = vbHourglass
   
   Dim Rst As adodb.Recordset
   
   Dim itmX As ListItem
      
   Dim fldNUM_PEDIDO
   Dim fldNUM_LINHA
   Dim fldID_SEQUENCIAL
   Dim fldDES_BLOQUEIO
   Dim fldSTATUS
   Dim fldDATA_STATUS
   Dim fldDES_MENSAGEM
   Dim fldID_BLOQUEIO
      
   Dim strORDENA_DATA As String
    
   Set Rst = New adodb.Recordset
      
   lvwPedido_Bloqueios_Pedido.ListItems.Clear
        
   Set Rst = Listar_Pedido_Bloqueios(gstrCod)
   
   Set fldNUM_PEDIDO = Rst.Fields("NUM_PEDIDO")
   Set fldNUM_LINHA = Rst.Fields("NUM_LINHA")
   Set fldID_SEQUENCIAL = Rst.Fields("ID_SEQUENCIAL")
   Set fldDES_BLOQUEIO = Rst.Fields("DES_BLOQUEIO")
   Set fldSTATUS = Rst.Fields("STATUS")
   Set fldDATA_STATUS = Rst.Fields("DATA_STATUS")
   Set fldDES_MENSAGEM = Rst.Fields("DES_MENSAGEM")
   Set fldID_BLOQUEIO = Rst.Fields("ID_BLOQUEIO")
          
   If Rst.EOF Then
   
      With Me.lvwPedido_Bloqueios_Pedido
          .ColumnHeaders.Clear
          .ListItems.Clear
          .ColumnHeaders.Add , , "Mensagem : Não existem registros selecionados.", 9000
      End With
   
   Else
   
      With lvwPedido_Bloqueios_Pedido
          .ListItems.Clear
          With .ColumnHeaders
            .Clear
            .Add , , "Seq.", 500
            .Add , , "Descrição Bloqueio", 500
            .Add , , "Status", 500
            .Add , , "Data do Status", 500
            .Add , , "Mensagem", 500
            .Add , , "Tipo Bloqueio", 500
            .Add , , "Data do Status", 500
            
         End With
      End With
      
      PreparaLista lvwPedido_Bloqueios_Pedido
     
      With Rst.Fields
         
         Rst.MoveFirst
      
         Do While Not Rst.EOF
     
         
            Set itmX = lvwPedido_Bloqueios_Pedido.ListItems.Add(, , IIf(Not Vazio(fldID_SEQUENCIAL), fldID_SEQUENCIAL, ""))
            
            itmX.SubItems(1) = IIf(Not Vazio(fldDES_BLOQUEIO), fldDES_BLOQUEIO, "")
            If fldSTATUS = "A" Then
                itmX.SubItems(2) = "Ativo"
            Else
                itmX.SubItems(2) = "Inativo"
            End If
            itmX.SubItems(3) = IIf(Not Vazio(fldDATA_STATUS), fldDATA_STATUS, "")
            itmX.SubItems(4) = IIf(Not Vazio(fldDES_MENSAGEM), fldDES_MENSAGEM, "")
                                                         
            Select Case fldID_BLOQUEIO
            
                Case "A"
                    itmX.SubItems(5) = "Alteração"
                Case "B"
                    itmX.SubItems(5) = "Cobrança"
                Case "C"
                    itmX.SubItems(5) = "CLIENTE"
                Case "E"
                    itmX.SubItems(5) = "Frete"
                Case "F"
                    itmX.SubItems(5) = "Configurador"
                Case "G"
                    itmX.SubItems(5) = "Grupo Ordem"
                Case "H"
                    itmX.SubItems(5) = "Entrega"
                Case "K"
                    itmX.SubItems(5) = "S Comp Kit"
                Case "L"
                    itmX.SubItems(5) = "Local Entrega"
                Case "M"
                    itmX.SubItems(5) = "Margem Min / Max"
                Case "N"
                    itmX.SubItems(5) = "Preço Min"
                Case "O"
                    itmX.SubItems(5) = "Vlr.Max Venda"
                Case "P"
                    itmX.SubItems(5) = "Produto"
                Case "Q"
                    itmX.SubItems(5) = "Qtde Min / Max"
                Case "R"
                    itmX.SubItems(5) = "Verif.Crédito"
                Case "S"
                    itmX.SubItems(5) = "Venda"
                Case "T"
                    itmX.SubItems(5) = "Cotas"
                Case "U"
                    itmX.SubItems(5) = "Fech.Ciclo"
                Case "V"
                    itmX.SubItems(5) = "Vendor HLD"
                Case "X"
                    itmX.SubItems(5) = "Qtde Min/Max CO"
                Case "Y"
                    itmX.SubItems(5) = "Tolerância.Zero"
                Case "Z"
                    itmX.SubItems(5) = "Prazo Médio"
            
            End Select
            
            If Not Vazio(fldDATA_STATUS) Then
                strORDENA_DATA = Right(fldDATA_STATUS, 4) & Mid(fldDATA_STATUS, 4, 2) & Left(fldDATA_STATUS, 2)
                itmX.SubItems(6) = strORDENA_DATA
            Else
                strORDENA_DATA = ""
                itmX.SubItems(6) = strORDENA_DATA
            End If
                                                                                                                              
            Rst.MoveNext
         Loop
      
      End With
                  
      lvwPedido_Bloqueios_Pedido.ColumnHeaders.Item(7).Width = 0
   
   End If
   
   Dim intPosicao As Double
    
   intPosicao = RetornaPosicaoList(lvwPedido_Bloqueios_Pedido)
   
   If intPosicao <> 0 Then
    
       lvwPedido_Bloqueios_Pedido.ListItems.Item(intPosicao).Selected = True
    
   End If
   
   Set Rst = Nothing
   
   Me.MousePointer = vbDefault
   
   Exit Sub
ValidaErro:
   
   Me.MousePointer = vbDefault
   TrataErro Err.Number, Err.Description, Err.Source, True, Me.Caption
   
End Sub

Private Sub Atualiza_Lista_Nota_Fiscal()
   
   On Error GoTo ValidaErro
   Me.MousePointer = vbHourglass
   
    Dim Rst As adodb.Recordset
   
    Dim itmX As ListItem
   
    
    Dim fldCOD_NOTA_FISCAL
    Dim fldSERIE
    Dim fldNUM_PEDIDO
    Dim fldCLIENTE
    Dim fldESTABELECIMENTO
    Dim fldCOD_FABRICA
    Dim fldSTATUS_NF
    Dim fldTIPO_NF
    Dim fldDATA_EMISSAO
    Dim fldDATA_SAIDA_MER
    Dim fldVALOR_BCICM
    Dim fldVALOR_ICM
    Dim fldVALOR_IPI
    Dim fldVALOR_ALIQICM
    Dim fldPESO_LIQ
    Dim fldPESO_BRUTO
    Dim fldVALOR_DESC
    Dim fldVALOR_TOTAL
    Dim fldTOTAL_UNID_FATUR
    Dim fldQTD_VOLUME
    Dim fldVIA_TRANSPORTE
    Dim fldDES_TRANSPORTE
    Dim fldVALOR_DESC_PONT
    Dim fldDES_QUALIDADE
    Dim fldCODMOEDA
    Dim fldDES_FABRICA
    
    Dim strORDENA_DATA As String
    
    Set Rst = New adodb.Recordset
      
    lvwNota_Fiscal_Pedido.ListItems.Clear
        
    Set Rst = Listar_Nota_Fiscal(, , gstrCod)
   
    Set fldCOD_NOTA_FISCAL = Rst.Fields("COD_NOTA_FISCAL")
    Set fldSERIE = Rst.Fields("SERIE")
    Set fldNUM_PEDIDO = Rst.Fields("NUM_PEDIDO")
    Set fldCLIENTE = Rst.Fields("CLIENTE")
    Set fldESTABELECIMENTO = Rst.Fields("ESTABELECIMENTO")
    Set fldCOD_FABRICA = Rst.Fields("COD_FABRICA")
    Set fldSTATUS_NF = Rst.Fields("STATUS_NF")
    Set fldTIPO_NF = Rst.Fields("TIPO_NF")
    Set fldDATA_EMISSAO = Rst.Fields("DATA_EMISSAO")
    Set fldDATA_SAIDA_MER = Rst.Fields("DATA_SAIDA_MER")
    Set fldVALOR_BCICM = Rst.Fields("VALOR_BCICM")
    Set fldVALOR_ICM = Rst.Fields("VALOR_ICM")
    Set fldVALOR_IPI = Rst.Fields("VALOR_IPI")
    Set fldVALOR_ALIQICM = Rst.Fields("VALOR_ALIQICM")
    Set fldPESO_LIQ = Rst.Fields("PESO_LIQ")
    Set fldPESO_BRUTO = Rst.Fields("PESO_BRUTO")
    Set fldVALOR_DESC = Rst.Fields("VALOR_DESC")
    Set fldVALOR_TOTAL = Rst.Fields("VALOR_TOTAL")
    Set fldTOTAL_UNID_FATUR = Rst.Fields("TOTAL_UNID_FATUR")
    Set fldQTD_VOLUME = Rst.Fields("QTD_VOLUME")
    Set fldVIA_TRANSPORTE = Rst.Fields("VIA_TRANSPORTE")
    Set fldDES_TRANSPORTE = Rst.Fields("DES_TRANSPORTE")
    Set fldVALOR_DESC_PONT = Rst.Fields("VALOR_DESC_PONT")
    Set fldDES_QUALIDADE = Rst.Fields("DES_QUALIDADE")
    Set fldCODMOEDA = Rst.Fields("CODMOEDA")
    Set fldDES_FABRICA = Rst.Fields("DES_FABRICA")
          
   If Rst.EOF Then
   
      With Me.lvwNota_Fiscal_Pedido
          .ColumnHeaders.Clear
          .ListItems.Clear
          .ColumnHeaders.Add , , "Mensagem : Não existem registros selecionados.", 9000
      End With
   
   Else
   
      With lvwNota_Fiscal_Pedido
          .ListItems.Clear
          With .ColumnHeaders
            .Clear
            .Add , , "Código", 500
            .Add , , "Série", 500, vbRightJustify
            .Add , , "Estabelecimento", 500, vbRightJustify
            .Add , , "Fábrica", 500
            .Add , , "Status NF", 500, vbRightJustify
            .Add , , "Tipo NF", 500, vbRightJustify
            .Add , , "Data Emissão", 500, vbRightJustify
            .Add , , "Data Saída Mercadoria", 500, vbRightJustify
            .Add , , "Valor BCICM", 500, vbRightJustify
            .Add , , "ICM", 500, vbRightJustify
            .Add , , "IPI", 500, vbRightJustify
            .Add , , "ALIQICM", 500, vbRightJustify
            .Add , , "Peso Líquido", 500, vbRightJustify
            .Add , , "Peso Bruto", 500, vbRightJustify
            .Add , , "Valor Descr.", 500, vbRightJustify
            .Add , , "Valor Total", 500, vbRightJustify
            .Add , , "Total Unidade Faturada", 500, vbRightJustify
            .Add , , "Qtde Volume", 500, vbRightJustify
            .Add , , "VIA Transporte", 500, vbRightJustify
            .Add , , "Descr. Transporte", 500, vbRightJustify
            .Add , , "Valor Descr. Pont.", 500, vbRightJustify
            .Add , , "Cód. Moeda", 500, vbRightJustify
            .Add , , "Qualidade", 500
            .Add , , "Data Emissão", 500, vbRightJustify
            .Add , , "Data Saída Mercadoria", 500, vbRightJustify
                        
         End With
      End With
      
      PreparaLista lvwNota_Fiscal_Pedido
     
      With Rst.Fields
         
         Rst.MoveFirst
      
         Do While Not Rst.EOF
     
        
     
         
            Set itmX = lvwNota_Fiscal_Pedido.ListItems.Add(, , fldCOD_NOTA_FISCAL)
            
            itmX.SubItems(1) = IIf(Not Vazio(fldSERIE), fldSERIE, "")
            itmX.SubItems(2) = IIf(Not Vazio(fldESTABELECIMENTO), fldESTABELECIMENTO, "")
            itmX.SubItems(3) = IIf(Not Vazio(fldDES_FABRICA), fldDES_FABRICA, "")
                        
            Select Case fldSTATUS_NF
              Case "A"
                itmX.SubItems(4) = "Contabilizado"
             Case "C"
                itmX.SubItems(4) = "Encerrado"
             Case "E"
                itmX.SubItems(4) = "Editado"
             Case "H"
                itmX.SubItems(4) = "Suspenso"
             Case "O"
                itmX.SubItems(4) = "Aberto"
             Case "V"
                itmX.SubItems(4) = "Transf.Voucher"
             Case "X"
                itmX.SubItems(4) = "Excluido"
            End Select
            
            itmX.SubItems(5) = IIf(Not Vazio(fldTIPO_NF), fldTIPO_NF, "")
            itmX.SubItems(6) = IIf(Not Vazio(fldDATA_EMISSAO), fldDATA_EMISSAO, "")
            itmX.SubItems(7) = IIf(Not Vazio(fldDATA_SAIDA_MER), fldDATA_SAIDA_MER, "")
            itmX.SubItems(8) = IIf(Not Vazio(Trim(fldVALOR_BCICM)), ObterCampoNumerico(fldVALOR_BCICM), "0")
            itmX.SubItems(9) = IIf(Not Vazio(Trim(fldVALOR_ICM)), ObterCampoNumerico(fldVALOR_ICM), "0")
            itmX.SubItems(10) = IIf(Not Vazio(Trim(fldVALOR_IPI)), ObterCampoNumerico(fldVALOR_IPI), "0")
            itmX.SubItems(11) = IIf(Not Vazio(Trim(fldVALOR_ALIQICM)), ObterCampoNumerico(fldVALOR_ALIQICM), "0")
            itmX.SubItems(12) = IIf(Not Vazio(Trim(fldPESO_LIQ)), ObterCampoNumerico(fldPESO_LIQ), "0")
            itmX.SubItems(13) = IIf(Not Vazio(Trim(fldPESO_BRUTO)), ObterCampoNumerico(fldPESO_BRUTO), "0")
            itmX.SubItems(14) = IIf(Not Vazio(Trim(fldVALOR_DESC)), ObterCampoNumerico(fldVALOR_DESC), "0")
            itmX.SubItems(15) = IIf(Not Vazio(Trim(fldVALOR_TOTAL)), ObterCampoNumerico(fldVALOR_TOTAL), "0")
            itmX.SubItems(16) = IIf(Not Vazio(Trim(fldTOTAL_UNID_FATUR)), ObterCampoNumerico(fldTOTAL_UNID_FATUR), "0")
            itmX.SubItems(17) = IIf(Not Vazio(Trim(fldQTD_VOLUME)), ObterCampoNumerico(fldQTD_VOLUME), "0")
            itmX.SubItems(18) = IIf(Not Vazio(fldVIA_TRANSPORTE), fldVIA_TRANSPORTE, "")
            itmX.SubItems(19) = IIf(Not Vazio(fldDES_TRANSPORTE), fldDES_TRANSPORTE, "")
            itmX.SubItems(20) = IIf(Not Vazio(Trim(fldVALOR_DESC_PONT)), ObterCampoNumerico(fldVALOR_DESC_PONT), "0")
            itmX.SubItems(21) = IIf(Not Vazio(fldCODMOEDA), fldCODMOEDA, "")
            itmX.SubItems(22) = IIf(Not Vazio(fldDES_QUALIDADE), fldDES_QUALIDADE, "")
                        
            If Not Vazio(fldDATA_EMISSAO) Then
                strORDENA_DATA = Right(fldDATA_EMISSAO, 4) & Mid(fldDATA_EMISSAO, 4, 2) & Left(fldDATA_EMISSAO, 2)
                itmX.SubItems(23) = strORDENA_DATA
            Else
                strORDENA_DATA = ""
                itmX.SubItems(23) = strORDENA_DATA
            End If
            
            If Not Vazio(fldDATA_SAIDA_MER) Then
                strORDENA_DATA = Right(fldDATA_SAIDA_MER, 4) & Mid(fldDATA_SAIDA_MER, 4, 2) & Left(fldDATA_SAIDA_MER, 2)
                itmX.SubItems(24) = strORDENA_DATA
            Else
                strORDENA_DATA = ""
                itmX.SubItems(24) = strORDENA_DATA
            End If
                                    
            Rst.MoveNext
         Loop
      
      End With
      
      lvwNota_Fiscal_Pedido.ColumnHeaders.Item(24).Width = 0
      lvwNota_Fiscal_Pedido.ColumnHeaders.Item(25).Width = 0
   
   End If
   
   Dim intPosicao As Double
    
   intPosicao = RetornaPosicaoList(lvwNota_Fiscal_Pedido)
   
   If intPosicao <> 0 Then
    
       lvwNota_Fiscal_Pedido.ListItems.Item(intPosicao).Selected = True
    
   End If
   
   Set Rst = Nothing
   
   Me.MousePointer = vbDefault
   
   Exit Sub
ValidaErro:
   
   Me.MousePointer = vbDefault
   TrataErro Err.Number, Err.Description, Err.Source, True, Me.Caption
   
End Sub




