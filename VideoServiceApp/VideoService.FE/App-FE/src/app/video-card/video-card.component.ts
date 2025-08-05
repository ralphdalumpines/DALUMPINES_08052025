import { Component, input } from '@angular/core';
import { VideoFile } from '../models/VideoFile';

@Component({
  selector: 'app-video-card',
  templateUrl: './video-card.component.html',
  styleUrls: ['./video-card.component.css']
})

export class VideoCardComponent {
 video = input.required<VideoFile>();
}
