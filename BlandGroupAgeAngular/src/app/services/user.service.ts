import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiUrl = 'https://localhost:7167/api';

  constructor(private http: HttpClient) { }

  getUserAge(birthDate: string | null | undefined): Observable<string> {
    const url = `${this.apiUrl}/userSettings/getUserAge?birthDate=${birthDate}`;
    let result = this.http.get<any>(url).pipe(
      map((response: any) => {
        return response.age as string;
      }) 
    );
    return result;
  }
}
