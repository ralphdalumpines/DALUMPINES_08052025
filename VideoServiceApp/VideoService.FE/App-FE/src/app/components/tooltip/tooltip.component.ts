import { Component, Input, HostListener } from '@angular/core';

@Component({
  selector: 'app-tooltip',
  templateUrl: './tooltip.component.html',
  styleUrls: ['./tooltip.component.css'],
})

export class TooltipComponent {
  @Input() text: string = '';
  show = false;

  @HostListener('mouseenter') onMouseEnter() {
    this.show = true;
  }
  @HostListener('mouseleave') onMouseLeave() {
    this.show = false;
  }
}
