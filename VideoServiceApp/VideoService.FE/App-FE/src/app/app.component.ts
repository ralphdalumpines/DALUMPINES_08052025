import { Component, signal } from '@angular/core';
import { AppPrimaryButtonComponent } from './app-primary-button/app-primary-button.component';
import { ListVideosComponent } from './pages/list-videos/list-videos.component';

@Component({
  selector: 'app-root',
  imports: [ AppPrimaryButtonComponent, ListVideosComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})

export class AppComponent {
  title = signal('App-FE');

  handleUploadButton() {
    console.log('Upload Video button clicked');
  }
}
