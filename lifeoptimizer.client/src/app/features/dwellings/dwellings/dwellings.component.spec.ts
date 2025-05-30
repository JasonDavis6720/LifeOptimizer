import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DwellingsComponent } from './dwellings.component';

describe('DwellingsComponent', () => {
  let component: DwellingsComponent;
  let fixture: ComponentFixture<DwellingsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DwellingsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DwellingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
