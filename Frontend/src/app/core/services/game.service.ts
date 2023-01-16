import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Game } from '../../data/game';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  private readonly route = 'game';

  constructor(private readonly apiService: ApiService) { }

  getAllGames(): Observable<Array<Game>> {

    return this.apiService.get(this.route);
  }
}
