import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ItemService } from 'src/app/core/services/item.service'; // Import the service

@Component({
  selector: 'app-add-item',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './add-item.component.html',
  styleUrls: ['./add-item.component.css'],
})
export class AddItemComponent {
  item = {
    name: '',
    description: '',
  };

  constructor(private itemService: ItemService) {}

  onSubmit() {
    // Call the service method to add the item
    this.itemService.addItem(this.item).subscribe({
      next: (response) => {
        console.log('Item added successfully:', response);
        // Optionally, clear the form or display a success message
      },
      error: (err) => {
        console.error('Error adding item:', err);
        // Handle error (e.g., display a message to the user)
      },
    });
  }
}
