import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RoomService } from '../services/room.service';

@Component({
  selector: 'app-add-room',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './add-rooms.component.html',
  styleUrls: ['./add-rooms.component.css'],
})
export class AddRoomComponent {
  room = {
    name: '',
    category: '',
  };

  constructor(private roomService: RoomService) {}
  
  onSubmit() {
    // Call the service method to add the item
    try {
      this.roomService.addRoom(this.room).subscribe({
        next: (response) => {
          console.log('Room added successfully:', response);
          // Optionally, clear the form or display a success message
        },
      });
    }
    catch (error) {
      console.error('Error adding room:', error);
    };
  }
}
