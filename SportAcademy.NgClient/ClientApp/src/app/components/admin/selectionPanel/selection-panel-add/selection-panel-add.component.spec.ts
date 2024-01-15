import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectionPanelAddComponent } from './selection-panel-add.component';

describe('SelectionPanelAddComponent', () => {
  let component: SelectionPanelAddComponent;
  let fixture: ComponentFixture<SelectionPanelAddComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SelectionPanelAddComponent]
    });
    fixture = TestBed.createComponent(SelectionPanelAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
