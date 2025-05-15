// src/app/layout/shell.component.ts
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AddItemComponent } from "../../features/items/components/add-item.component";
import { AddRoomComponent } from "../../features/rooms/components/add-rooms.component";
 // Import RouterModule

@Component({
  selector: 'app-shell',
  standalone: true,
  imports: [RouterModule, AddItemComponent, AddRoomComponent], // Add RouterModule here
  templateUrl: `./shell.component.html`,
  styleUrls: ['./shell.component.css'],
})
export class ShellComponent { }
