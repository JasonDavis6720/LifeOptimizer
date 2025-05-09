import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

interface Item {
  name: string;
  description: string;
  // Add other fields as needed
}

@Injectable({
  providedIn: 'root',
})
export class ItemService {
  private apiUrl = 'https://localhost:7142/items'; // Replace with your API endpoint

  constructor(private http: HttpClient) {}

  // Method to create a new item
  addItem(item: Item): Observable<Item> {
    return this.http.post<Item>(this.apiUrl, item);
  }
}
