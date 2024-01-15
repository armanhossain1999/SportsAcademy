import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagerDeleteComponent } from './manager-delete.component';

describe('ManagerDeleteComponent', () => {
  let component: ManagerDeleteComponent;
  let fixture: ComponentFixture<ManagerDeleteComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ManagerDeleteComponent]
    });
    fixture = TestBed.createComponent(ManagerDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
