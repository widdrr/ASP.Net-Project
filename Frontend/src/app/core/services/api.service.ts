import { HttpClient } from '@angular/common/http'
import { Inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiServiceService {
  private apiUrl: string = "";
  constructor(private readonly HttpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) { }
}
