// WARNING
// This file has been generated automatically by Visual Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <AppKit/AppKit.h>


@interface ConfigureViewController : NSViewController {
	NSTextField *_lblWorkspace;
	NSTextField *_lblWorkspaceDescription;
}

@property (nonatomic, retain) IBOutlet NSTextField *lblWorkspace;

@property (nonatomic, retain) IBOutlet NSTextField *lblWorkspaceDescription;

- (IBAction)backupClick:(id)sender;

- (IBAction)changeFolders:(id)sender;

- (IBAction)showFolders:(id)sender;

@end
