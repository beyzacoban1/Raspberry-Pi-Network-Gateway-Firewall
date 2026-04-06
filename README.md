Project Overview
This project transforms a Raspberry Pi into a Smart Network Gateway capable of managing and securing local area network (LAN) traffic. By implementing Layer 3 Routing and Network Address Translation (NAT), the Pi acts as the central node for all connected clients.

The core of the project is a hybrid system:

Traffic Control: Utilizes Linux iptables and dnsmasq for deep packet inspection (DPI) at a basic level, allowing for string-based content filtering and domain blocking.

Real-Time Monitoring: A custom C# (.NET 8) application monitors kernel logs in real-time. It parses connection states (NEW, ACCEPT, DROP) and provides instant physical feedback.

Hardware Integration: Leverages Raspberry Pi’s GPIO interface to visualize network activity through LED indicators, creating a bridge between software-defined rules and physical status monitoring.
