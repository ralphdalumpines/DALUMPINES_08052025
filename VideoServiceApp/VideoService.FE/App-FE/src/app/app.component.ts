import { Component, signal } from '@angular/core';
import { ListVideosComponent } from './pages/list-videos/list-videos.component';

@Component({
  selector: 'app-root',
  imports: [ ListVideosComponent ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})

export class AppComponent {
  title = signal('App-FE');

  handleUploadButton() {
    console.log('Upload Video button clicked');
    // Logic to handle video upload can be added here
  }
  handleViewListButton() {
    console.log('View List Videos button clicked');
    // Logic to navigate to the list of videos can be added here
  }
}
