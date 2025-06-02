import { Routes } from '@angular/router';
import { AddItemComponent } from './features/items/components/add-item.component';
import { AddRoomComponent } from './features/rooms/components/add-rooms.component';


export const routes: Routes = [
  { path: 'add-item', component: AddItemComponent },
  { path: 'add-room', component: AddRoomComponent },
];
