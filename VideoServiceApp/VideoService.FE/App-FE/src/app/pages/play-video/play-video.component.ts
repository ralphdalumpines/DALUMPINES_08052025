import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-play-video',
  templateUrl: './play-video.component.html',
  styleUrls: ['./play-video.component.css']
})

export class PlayVideoComponent {
  videoUrl = signal<string>('');
}
