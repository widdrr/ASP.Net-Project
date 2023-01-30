import { Component } from '@angular/core';
import { LibraryService } from './core/services/library.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Frontend';
  constructor(private readonly libraryService: LibraryService) {
    console.log("App Created");
  }
}
