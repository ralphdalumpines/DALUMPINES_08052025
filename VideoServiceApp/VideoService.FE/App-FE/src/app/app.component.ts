import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent {
  title = signal('App-FE');

  handleUploadButton() {
    // Logic to handle the upload button click
    console.log('Upload Video button clicked');
  }
}
