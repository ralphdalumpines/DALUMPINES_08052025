import { Component, input } from '@angular/core';
import { VideoFile } from '../../models/VideoFile';

@Component({
  selector: 'app-play-video',
  templateUrl: './play-video.component.html',
  styleUrls: ['./play-video.component.css']
})

export class PlayVideoComponent {
  video = input.required<VideoFile>(); 
}
