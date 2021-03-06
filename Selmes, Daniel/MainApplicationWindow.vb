﻿''' <summary>
''' The main startup application for the deadsouls-creator software
''' This provides lists of game files so you can easily open them for editing, and manages the locations of game files, so that the individual modules don't have to locate them.
''' </summary>
Public Class MainApplicationWindow

    Private Sub MainApplicationWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitialiseLogging("logfile.txt", levels.debug)
        'Check deadsouls installation path
        If My.Settings.deadsouls_installation_path = "" Then
            Dim path_dialog As New ds_path_dialog
            path_dialog.ShowDialog()
        End If

        WriteToLog("Deadsouls Path: " & My.Settings.deadsouls_installation_path)
        If My.Settings.deadsouls_installation_path = "NOINSTALLPATH" Then
            RefreshFilesToolStripMenuItem.Enabled = False
        End If

        'Populate the list boxes from settings
        Try
            RoomsListBox.Items.Clear()
            RoomsListBox.Items.Add("Build new room...")
            For Each room In My.Settings.rooms_list
                RoomsListBox.Items.Add(room)
            Next
        Catch ex As Exception

        End Try
        Try
            ItemListBox.Items.Clear()
            ItemListBox.Items.Add("Craft new item...")
            For Each room In My.Settings.items_list
                ItemListBox.Items.Add(room)
            Next
        Catch ex As Exception

        End Try
        Try
            WeaponsListBox.Items.Clear()
            WeaponsListBox.Items.Add("Forge new weapon...")
            For Each weapon In My.Settings.weapon_list
                WeaponsListBox.Items.Add(weapon)
            Next
        Catch ex As Exception

        End Try
        Try
            ArmourListBox.Items.Clear()
            ArmourListBox.Items.Add("Forge new armour...")
            For Each armour In My.Settings.armour_list
                ArmourListBox.Items.Add(armour)
            Next
        Catch ex As Exception

        End Try
        Try
            NPCListBox.Items.Clear()
            NPCListBox.Items.Add("Make new NPC...")
            For Each npc In My.Settings.NPC_list
                NPCListBox.Items.Add(npc)
            Next
        Catch ex As Exception

        End Try

        'Select the "create new [thing]" option by default for all the file lists
        RoomsListBox.SelectedItem = "Build new room..."
        NPCListBox.SelectedItem = "Make new NPC..."
        WeaponsListBox.SelectedItem = "Forge new weapon..."
        ArmourListBox.SelectedItem = "Forge new armour..."
        ItemListBox.SelectedItem = "Craft new item..."

    End Sub

    Private Sub QuitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub EditRoomButton_Click(sender As Object, e As EventArgs) Handles EditRoomButton.Click
        If RoomsListBox.SelectedItem = "Build new room..." Then
            'Create a new room
            Dim roomeditor As New RoomEditor()
            roomeditor.Show()
        Else
            'Open the selected room in the room editor
            Dim roomeditor As New RoomEditor()
            roomeditor.filePath = RoomsListBox.SelectedItem
            roomeditor.Show()
        End If
    End Sub

    Private Sub EditNPCButton_Click(sender As Object, e As EventArgs) Handles EditNPCButton.Click
        If NPCListBox.SelectedItem = "Make new NPC..." Then
            'Create a new NPC
            Dim editor As New NPCEditor
            editor.Show()
        Else
            'Open the selected NPC in the NPC editor
            Dim editor As New NPCEditor
            editor.filepath = NPCListBox.SelectedItem
            editor.Show()
        End If
    End Sub

    Private Sub EditWeaponButton_Click(sender As Object, e As EventArgs) Handles EditWeaponButton.Click
        If WeaponsListBox.SelectedItem = "Forge new weapon..." Then
            'Create a new weapon
            Dim weapon As New WeaponEditor
            weapon.Show()
        Else
            'Open the selected weapon in the weapon editor
            Dim weapon As New WeaponEditor
            weapon.filepath = WeaponsListBox.SelectedItem
            weapon.Show()
        End If
    End Sub

    Private Sub EditArmourButton_Click(sender As Object, e As EventArgs) Handles EditArmourButton.Click
        If ArmourListBox.SelectedItem = "Forge new armour..." Then
            'Create new armour
            ' MsgBox("Creating new armour in armour editor...")
            Dim armour As New Armour
            armour.Show()
        Else
            'Open the selected armour in the armour editor
            ' MsgBox("Opening file " + ArmourListBox.SelectedItem.ToString() + " in armour editor...")
            Dim armour As New Armour
            armour.filepath = ArmourListBox.SelectedItem
            armour.Show()
        End If
    End Sub

    Private Sub DeadsoulsInstallationPathToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeadsoulsInstallationPathToolStripMenuItem.Click
        Dim path_dialog As New ds_path_dialog
        path_dialog.ShowDialog()
        WriteToLog("Deadsouls Path: " & My.Settings.deadsouls_installation_path)
        If My.Settings.deadsouls_installation_path = "NOINSTALLPATH" Then
            RefreshFilesToolStripMenuItem.Enabled = False
        Else
            RefreshFilesToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub EditItemButton_Click(sender As Object, e As EventArgs) Handles EditItemButton.Click
        If ItemListBox.SelectedItem = "Craft new item..." Then
            'Create new item
            Dim itemeditor As New ItemEditor
            itemeditor.Show()
        Else
            'Open the selected item in the armour editor
            Dim itemeditor As New ItemEditor
            itemeditor.filePath = ItemListBox.SelectedItem
            itemeditor.Show()
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox.ShowDialog()
    End Sub

    Private Sub RefreshFilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshFilesToolStripMenuItem.Click
        FileScanDialog.ShowDialog()
        Try
            RoomsListBox.Items.Clear()
            RoomsListBox.Items.Add("Build new room...")
            For Each room In My.Settings.rooms_list
                RoomsListBox.Items.Add(room)
            Next
        Catch ex As Exception

        End Try
        Try
            ItemListBox.Items.Clear()
            ItemListBox.Items.Add("Craft new item...")
            For Each room In My.Settings.items_list
                ItemListBox.Items.Add(room)
            Next
        Catch ex As Exception

        End Try
        Try
            WeaponsListBox.Items.Clear()
            WeaponsListBox.Items.Add("Forge new weapon...")
            For Each weapon In My.Settings.weapon_list
                WeaponsListBox.Items.Add(weapon)
            Next
        Catch ex As Exception

        End Try
        Try
            ArmourListBox.Items.Clear()
            ArmourListBox.Items.Add("Forge new armour...")
            For Each armour In My.Settings.armour_list
                ArmourListBox.Items.Add(armour)
            Next
        Catch ex As Exception

        End Try
        Try
            NPCListBox.Items.Clear()
            NPCListBox.Items.Add("Make new NPC...")
            For Each npc In My.Settings.NPC_list
                NPCListBox.Items.Add(npc)
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub NewRoomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewRoomToolStripMenuItem.Click
        Dim editor As New RoomEditor()
        editor.Show()
    End Sub

    Private Sub NewItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewItemToolStripMenuItem.Click
        Dim editor As New ItemEditor()
        editor.Show()
    End Sub

    Private Sub NewNPCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewNPCToolStripMenuItem.Click
        Dim editor As New NPCEditor()
        editor.Show()
    End Sub

    Private Sub NewArmourToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewArmourToolStripMenuItem.Click
        Dim editor As New Armour()
        editor.Show()
    End Sub

    Private Sub NewWeaponsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewWeaponsToolStripMenuItem.Click
        Dim editor As New WeaponEditor()
        editor.Show()
    End Sub
End Class