object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 366
  ClientWidth = 562
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object FullHashTable: TMemo
    Left = 24
    Top = 24
    Width = 169
    Height = 329
    ReadOnly = True
    TabOrder = 0
  end
  object GenerateTable: TButton
    Left = 384
    Top = 22
    Width = 83
    Height = 25
    Caption = #1043#1077#1085#1077#1088#1080#1088#1086#1074#1072#1090#1100
    TabOrder = 1
    OnClick = GenerateTableClick
  end
  object CuttingNumber: TEdit
    Left = 384
    Top = 332
    Width = 83
    Height = 21
    TabOrder = 2
  end
  object HashTableLess: TMemo
    Left = 206
    Top = 24
    Width = 162
    Height = 161
    ReadOnly = True
    TabOrder = 3
  end
  object HashTableMore: TMemo
    Left = 206
    Top = 191
    Width = 162
    Height = 162
    ReadOnly = True
    TabOrder = 4
  end
  object Cut: TButton
    Left = 479
    Top = 330
    Width = 75
    Height = 25
    Caption = #1056#1072#1079#1073#1080#1090#1100
    Default = True
    TabOrder = 5
    OnClick = CutClick
  end
end
