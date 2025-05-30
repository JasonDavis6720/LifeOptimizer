import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ItemService } from 'src/app/features/items/services/item.service'; // Import the service

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
    category: '',
  };

  constructor(private itemService: ItemService) {}

  onSubmit() {
    // Call the service method to add the item
    try {
      this.itemService.addItem(this.item).subscribe({
        next: (response) => {
          console.log('Item added successfully:', response);
          // Optionally, clear the form or display a success message
        },
      });
    }
    catch (error) {
      console.error('Error adding item:', error);
    };
  }
}

