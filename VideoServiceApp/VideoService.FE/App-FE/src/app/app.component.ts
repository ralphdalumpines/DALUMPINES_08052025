import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  standalone: true
})

export class AppComponent {
  title = signal('App-FE');

  handleUploadButton() {
    console.log('Upload Video button clicked');
  }
}
