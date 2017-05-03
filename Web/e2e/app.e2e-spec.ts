import { AgeRangerPage } from './app.po';

describe('age-ranger App', function() {
  let page: AgeRangerPage;

  beforeEach(() => {
    page = new AgeRangerPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
