import { Component, input } from '@angular/core';
import { VideoFile } from '../../models/VideoFile';
import { Router } from '@angular/router';
import { TooltipComponent } from '../tooltip/tooltip.component';

@Component({
  selector: 'app-video-card',
  imports: [TooltipComponent],
  templateUrl: './video-card.component.html',
  styleUrls: ['./video-card.component.css']
})

export class VideoCardComponent {
  video = input.required<VideoFile>();

  constructor(private router: Router) {}

  playVideo() {
    this.router.navigate(['/play-video', this.video().id]);
  }
}
