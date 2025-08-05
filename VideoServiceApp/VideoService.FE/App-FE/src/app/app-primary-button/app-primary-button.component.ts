import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-primary-button',
  templateUrl: './app-primary-button.component.html',
  styleUrls: ['./app-primary-button.component.css']
})
export class AppPrimaryButtonComponent {
  @Input() label: string = 'Button';
  @Input() type: string = 'button';
}
