import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private readonly route = 'user';

  constructor(private readonly apiService: ApiService) { }

  login(loginBody: any) : Observable<any> {

    return this.apiService.post<any>(`${this.route}/authenticate`, loginBody).pipe(
      map((response: any) => {
        if (response) {
          localStorage.setItem('token', response.token);
          localStorage.setItem('userId',response.id)
        }
      })
    );
  }
  register(registerBody: any) : Observable<any> {
    return this.apiService.post<any>(`${this.route}`, registerBody);
  }

  isLoggedIn(): boolean {
    const token = localStorage.getItem('token');
    return token != null;
  }

  logout(): void {
    localStorage.removeItem('token');
  }
} 
