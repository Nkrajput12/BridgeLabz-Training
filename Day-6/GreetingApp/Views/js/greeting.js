async function submitMyForm(e) {
    e.preventDefault(); // Stop page reload

    const nameValue = document.getElementById('Name').value;

    try {
        // 1. Post the data
        const saveResponse = await fetch('/Home/SaveName', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ Name: nameValue })
        });
        
        const saveData = await saveResponse.json();
        
        if (saveData.success) {
            // 2. Fetch the greeting message
            const msgResponse = await fetch('/Home/GetMessage');
            const msgData = await msgResponse.json();
            
            // 3. Show it in a popup
            if (msgData.message) {
                alert(msgData.message);
            }
        }
    } catch (error) {
        console.error("Error:", error);
    }
}
