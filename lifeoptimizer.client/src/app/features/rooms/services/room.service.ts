import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

interface Room {
  name: string;
  category: string;
  // Add other fields as needed
}

@Injectable({
  providedIn: 'root',
})
export class RoomService {
  private apiUrl = 'https://localhost:7142/api/Room'; // Replace with your API endpoint

  constructor(private http: HttpClient) {}

  // Method to create a new item
  addRoom(room: Room): Observable<Room> {
    return this.http.post<Room>(this.apiUrl, room);
  }
}
