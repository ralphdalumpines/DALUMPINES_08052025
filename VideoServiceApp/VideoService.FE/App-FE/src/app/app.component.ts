import { Component, signal } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ListVideosComponent } from './pages/list-videos/list-videos.component';
import { UploadVideoComponent } from './pages/upload-video/upload-video.component';

@Component({
  selector: 'app-root',
  imports: [ RouterModule, ListVideosComponent , UploadVideoComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})

export class AppComponent {
  title = signal('App-FE');
}
